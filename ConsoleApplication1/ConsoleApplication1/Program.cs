using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime end;
            DateTime start = DateTime.Now;
            //Only uncomment this first group if you want to loop without doing anything else.
            //ForVsForeachVsWhile(100, false, true);
            //ForVsForeachVsWhile(50000, false, true);
            //ForVsForeachVsWhile(250000, false, true);
            //ForVsForeachVsWhile(5000000, false, true);
            //ForVsForeachVsWhile(100, true, true);
            //ForVsForeachVsWhile(50000, true, true);
            //ForVsForeachVsWhile(250000, true, true);
            //ForVsForeachVsWhile(5000000, true, true);
            ForVsForeachVsWhile(100, false, false);
            ForVsForeachVsWhile(50000, false, false);
            ForVsForeachVsWhile(250000, false, false);
            ForVsForeachVsWhile(5000000, false, false);
            ForVsForeachVsWhile(100, true, false);
            ForVsForeachVsWhile(50000, true, false);
            ForVsForeachVsWhile(250000, true, false);
            ForVsForeachVsWhile(5000000, true, false);
            end = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("### Overall End Time: " + end.ToLongTimeString());
            Console.WriteLine("### Overall Run Time: " + (end - start));
            Console.WriteLine();
            Console.WriteLine("Hit Enter to Exit");
            Console.ReadLine();
        }
        //#########################################################################################################
        //For vs ForEach vs While loop
        //Not accessing items in the collections
        //Then do it accessing items in the collection
        //http://www.dotnetperls.com/for-foreach
        public class ForVsForeachVsWhileTestClass
        {   //Simple custom object for the test since there will be a lot of custom classes out there
            public Guid g;
            public string s;
            public Dictionary;Guid, string&gt; d;
            public int i = 0;
            private bool b = false;
            private decimal dc = 1201.2016M;
        }
        //This method does access values in the collections
        //NumberOfItems - the number of objects to create in each collection and the number of loops to run
        //DoParallelLoops - test the parallel for and foreach speeds
        //JustDoPureLooping - do the loops without any other logic 
        static void ForVsForeachVsWhile(int NumberOfItems, bool DoParallelLoops, bool JustDoPureLooping)
        {
            Console.WriteLine();
            Console.WriteLine("######## " + System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.WriteLine("Number of loops: " + NumberOfItems.ToString("#,##0"));
            Console.WriteLine("DoParallelLoops: " + DoParallelLoops.ToString());
            Console.WriteLine("JustDoPureLooping: " + JustDoPureLooping.ToString());
            Console.WriteLine();
            object lockObject = new object();
            long runningTotal = 0;
            int index = 0; //used for while loops
            Stopwatch sw = new Stopwatch();
            DateTime end = DateTime.Now;
            DateTime start = DateTime.Now;
            //the collections to loop over
            int[] i = new int[NumberOfItems];
            List l = new List(NumberOfItems);
            Dictionary & lt; int, string&gt; d = new Dictionary& lt; int, string&gt; (NumberOfItems);
            List lf = new List(NumberOfItems);
            DataTable dt = new DataTable();
            DataColumn dtc1 = new DataColumn("Col1");
            DataColumn dtc2 = new DataColumn("Col2");
            DataColumn dtc3 = new DataColumn("Col3");
            DataColumn dtc4 = new DataColumn("Col4");
            dtc1.DataType = System.Type.GetType("System.Int32");
            dtc2.DataType = System.Type.GetType("System.String");
            dtc3.DataType = System.Type.GetType("System.Guid");
            dtc4.DataType = System.Type.GetType("System.Double");
            dt.Columns.Add(dtc1);
            dt.Columns.Add(dtc2);
            dt.Columns.Add(dtc3);
            dt.Columns.Add(dtc4);
            DataRow[] dr = new DataRow[NumberOfItems];
            //initialize everything
            for (int x = 0; x & lt; NumberOfItems; x++)
            {
                i[x] = x;
                l.Add(x.ToString());
                d.Add(x, x.ToString());
                ForVsForeachVsWhileTestClass c = new ForVsForeachVsWhileTestClass();
                c.g = Guid.NewGuid();
                c.s = x.ToString();
                c.i = x;
                c.d = new Dictionary& lt; Guid, string&gt; ();
                c.d.Add(c.g, c.s);
                lf.Add(c);
                dr[x] = dt.NewRow();
                dr[x][dtc1] = x;
                dr[x][dtc2] = c.g.ToString() + " " + x.ToString();
                dr[x][dtc3] = c.g;
                dr[x][dtc4] = Int32.MaxValue / (x == 0 ? 1 : x);
            }
            dt = dr.CopyToDataTable();
            //int[] -----------------------------------------------------------------------
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "For-Loop over int[] at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.For(0, i.Length,
                    () = &gt; 0L,
                    (x, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += i[x];
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                runningTotal = 0;
                sw.Restart();
                for (int x = 0; x & lt; i.Length; x++)                 
                {
                    if (!JustDoPureLooping)
                        runningTotal += i[x];
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "ForEach over int[] at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.ForEach(i,
                    () = &gt; 0L,
                    (x, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += x;
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                foreach (int x in i)
                {
                    if (!JustDoPureLooping)
                        runningTotal += x;
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            if (!DoParallelLoops)
            {
                runningTotal = 0;
                Console.WriteLine("###########################################################");
                Console.WriteLine("Starting While over int[] at: " + DateTime.Now.ToLongTimeString());
                sw.Restart();
                index = 0;
                while (index & lt; i.Length)
                {
                    if (!JustDoPureLooping)
                        runningTotal += i[index];
                    index += 1;
                }
                sw.Stop();
                Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
                Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
                Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
                Thread.Sleep(500);
            }
            //List -----------------------------------------------------------------------
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "For-Loop over List at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.For(0, l.Count,
                    () = &gt; 0L,
                    (x, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(l[x]);
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                for (int x = 0; x & lt; l.Count; x++)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(l[x]);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "ForEach over List at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.ForEach(l,
                    () = &gt; 0L,
                    (s, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(s);
                    return subtotal;
                },
                    (sum) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += sum;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                foreach (string s in l)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(s);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            if (!DoParallelLoops)
            {
                runningTotal = 0;
                Console.WriteLine("###########################################################");
                Console.WriteLine("Starting While over List at: " + DateTime.Now.ToLongTimeString());
                sw.Restart();
                index = 0;
                while (index & lt; l.Count)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(l[index]);
                    index += 1;
                }
                sw.Stop();
                Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
                Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
                Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
                Thread.Sleep(500);
            }

            //Dictionary&lt;int,string&gt; -----------------------------------------------------------------------
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "For-Loop over Dictionary&lt;int, string&gt; at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.For(0, d.Count,
                    () = &gt; 0L,
                    (x, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(d[x]);
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                for (int x = 0; x & lt; d.Count; x++)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(d[x]);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "ForEach over Dictionary&lt;int, string&gt; at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.ForEach(d.Values,
                    () = &gt; 0L,
                    (s, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(s);
                    return subtotal;
                },
                    (sum) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += sum;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                foreach (string s in d.Values)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(s);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            if (!DoParallelLoops)
            {
                runningTotal = 0;
                Console.WriteLine("###########################################################");
                Console.WriteLine("Starting While over Dictionary&lt;int, string&gt; at: " + DateTime.Now.ToLongTimeString());
                sw.Restart();
                index = 0;
                while (index & lt; d.Count)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(d[index]);
                    index += 1;
                }
                sw.Stop();
                Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
                Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
                Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
                Thread.Sleep(500);
            }
            //List -----------------------------------------------------------------------
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "For-Loop over List at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.For(0, lf.Count,
                    () = &gt; 0L,
                    (x, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += lf[x].i;
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                for (int x = 0; x & lt; lf.Count; x++)
                {
                    if (!JustDoPureLooping)
                        runningTotal += lf[x].i;
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "ForEach over List at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.ForEach(lf,
                    () = &gt; 0L,
                    (f, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += f.i;
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                foreach (ForVsForeachVsWhileTestClass f in lf)
                {
                    if (!JustDoPureLooping)
                        runningTotal += f.i;
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            if (!DoParallelLoops)
            {
                runningTotal = 0;
                Console.WriteLine("###########################################################");
                Console.WriteLine("Starting While over List at: " + DateTime.Now.ToLongTimeString());
                sw.Restart();
                index = 0;
                while (index & lt; lf.Count)
                {
                    if (!JustDoPureLooping)
                        runningTotal += lf[index].i;
                    index += 1;
                }
                sw.Stop();
                Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
                Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
                Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
                Thread.Sleep(500);
            }
            //DataRows[] -----------------------------------------------------------------------
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "For-Loop over DataRows[] at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.For(0, dr.Length,
                    () = &gt; 0L,
                    (x, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(dr[x]["Col1"]);
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                for (int x = 0; x & lt; dr.Length; x++)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(dr[x]["Col1"]);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "ForEach over DataRows[] at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.ForEach(dr,
                    () = &gt; 0L,
                    (ddr, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(ddr["Col1"]);
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                foreach (DataRow ddr in dr)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(ddr["Col1"]);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            if (!DoParallelLoops)
            {
                runningTotal = 0;
                Console.WriteLine("###########################################################");
                Console.WriteLine("Starting While over DataRows[] at: " + DateTime.Now.ToLongTimeString());
                sw.Restart();
                index = 0;
                while (index & lt; dr.Length)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(dr[index]["Col1"]);
                    index += 1;
                }
                sw.Stop();
                Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
                Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
                Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
                Thread.Sleep(500);
            }
            //Datatable -----------------------------------------------------------------------
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "For-Loop over Datatable at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.For(0, dt.Rows.Count,
                () = &gt; 0L,
                    (x, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(dt.Rows[x]["Col1"]);
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                for (int x = 0; x & lt; dt.Rows.Count; x++)                 
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(dt.Rows[x]["Col1"]);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            runningTotal = 0;
            Console.WriteLine("###########################################################");
            Console.WriteLine("Starting " + (DoParallelLoops ? "Parallel " : "") + "ForEach over Datatable at: " + DateTime.Now.ToLongTimeString());
            if (DoParallelLoops)
            {
                sw.Restart();
                Parallel.ForEach(dt.AsEnumerable(),
                    () = &gt; 0L,
                    (dtdr, loopState, subtotal) = &gt;
                {
                    if (!JustDoPureLooping)
                        subtotal += Convert.ToInt32(dtdr["Col1"]);
                    return subtotal;
                },
                    (s) = &gt;
                {
                    lock (lockObject)
                    {
                        runningTotal += s;
                    }
                }
                );
                sw.Stop();
            }
            else
            {
                sw.Restart();
                foreach (DataRow dtdr in dt.Rows)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(dtdr["Col1"]);
                }
                sw.Stop();
            }
            Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
            Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
            Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            Thread.Sleep(500);
            if (!DoParallelLoops)
            {
                runningTotal = 0;
                Console.WriteLine("###########################################################");
                Console.WriteLine("Starting While over Datatable at: " + DateTime.Now.ToLongTimeString());
                sw.Restart();
                index = 0;
                while (index & lt; dt.Rows.Count)
                {
                    if (!JustDoPureLooping)
                        runningTotal += Convert.ToInt32(dt.Rows[index]["Col1"]);
                    index += 1;
                }
                sw.Stop();
                Console.WriteLine("Finished at: " + DateTime.Now.ToLongTimeString());
                Console.WriteLine("Running Total: " + runningTotal.ToString("#,##0"));
                Console.WriteLine("Time: " + sw.Elapsed.ToString("mm\\:ss\\.fffffff"));
            }
            //cleanup
            if (i != null)
                Array.Clear(i, 0, i.Length);
            i = null;
            if (l != null)
                l.Clear();
            l = null;
            if (d != null)
                d.Clear();
            d = null;
            if (lf != null)
                lf.Clear();
            lf = null;
            if (dr != null)
                Array.Clear(dr, 0, dr.Length);
            dr = null;
            if (dt != null)
                dt.Clear();
            dt.Dispose();
            dt = null;
            GC.Collect(1, GCCollectionMode.Forced, true);
        }
    } //class
}
