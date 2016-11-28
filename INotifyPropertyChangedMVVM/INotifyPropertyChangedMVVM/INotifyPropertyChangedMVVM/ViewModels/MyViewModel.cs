using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace INotifyPropertyChangedMVVM.ViewModels
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private string fornavn;
        private bool fornavnOk = false;
        private string status = "Indtast navn";

        public string Fornavn
        {
            get { return fornavn; }
            set
            {
                if (fornavn != value)
                {
                    fornavn = value;
                    OnPropertyChanged("Fornavn"); // implicit
                                                  // or OnPropertyChanged(); explicit:  The compiler sets thes string

                    if (String.IsNullOrEmpty(Fornavn) || String.IsNullOrWhiteSpace(Fornavn))
                    {
                        FornavnOk = false;
                        Status = "Indtast navn...";
                    }
                    else
                    {
                        FornavnOk = true;
                        Status = "Navn: " + Fornavn;
                    }
                }

            }
        }

        public bool FornavnOk
        {
            get { return fornavnOk; }
            set
            {
                if (fornavnOk != value)
                {
                    fornavnOk = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    OnPropertyChanged();
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // CallerMemberName is used to set propertyName if none...
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var myEvent = PropertyChanged;
            if (myEvent != null)
            {
                myEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
