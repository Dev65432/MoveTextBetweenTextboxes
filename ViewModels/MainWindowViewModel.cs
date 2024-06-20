using MoveTextBetweenTextboxes.Commands;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MoveTextBetweenTextboxes.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            
        }


        private string _title = "Главное_окно_программы";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;

                OnPropertyChanged(nameof(Title));
            }
        }
        

        #region ItemsTesting
 
        private string _itemsOriginal;
        public string ItemsOriginal
        {
            get { return _itemsOriginal; }
            set
            {
                _itemsOriginal = value;

                OnPropertyChanged(nameof(ItemsOriginal));
            }
        }

        private string _ItemsQueue;
        public string ItemsQueue
        {
            get { return _ItemsQueue; }
            set
            {
                _ItemsQueue = value;

                OnPropertyChanged(nameof(ItemsQueue));
            }
        }

        private string _ItemsCompleted;
        public string ItemsCompleted
        {
            get { return _ItemsCompleted; }
            set
            {
                _ItemsCompleted = value;

                OnPropertyChanged(nameof(ItemsCompleted));
            }
        }

        private string _ItemsErros;
        public string ItemsErros
        {
            get { return _ItemsErros; }
            set
            {
                _ItemsErros = value;

                OnPropertyChanged(nameof(ItemsErros));
            }
        }
        #endregion


        private ICommand _GetPersonsCommand;
        public ICommand GetPersonsCommand
        {
            get
            {                
                return _GetPersonsCommand ??
                    (_GetPersonsCommand = new RelayCommand(() => OnGetPersonsExecuted5()));
            }
        }

        private async Task OnGetPersonsExecuted5()
        {
            var items = ItemsOriginal.Split(new[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                        
            ItemsQueue = ItemsOriginal;

            
            for (int i = 0; i < items.Count; i++)
            {
               // await Thread.Sleep(1000);

                // string item = "Item-" + i;
                string item = "";
                if (i % 2 == 0)
                {
                    item = ItemsQueue.Substring(i);                    
                    ItemsCompleted = ItemsCompleted + item + "\n";
                }
                else
                {
                    item = ItemsQueue.Substring(i);                    
                    ItemsErros = ItemsErros +  item + "\n";
                }

            }
        }

      
    }



}


