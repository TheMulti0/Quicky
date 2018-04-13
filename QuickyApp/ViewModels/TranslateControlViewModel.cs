using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EasyTranslate.Enums;
using EasyTranslate.Words;
using QuickyApp.Annotations;
using QuickyApp.Models;

namespace QuickyApp.ViewModels
{
    internal class TranslateControlViewModel : INotifyPropertyChanged, IPageViewModel
    {
        private TranslateLanguages _chosenLanguage;
        private TranslateWord _finalWord;
        private string _originalWord;

        public IEnumerable<TranslateLanguages> Languages { get; set; }

        public TranslateLanguages ChosenLanguage
        {
            get => _chosenLanguage;
            set
            {
                if (_chosenLanguage == value)
                {
                    return;
                }
                _chosenLanguage = value;
                OnPropertyChanged();
            }
        }

        public string OriginalWord
        {
            get => _originalWord;
            set
            {
                if (_originalWord == value)
                {
                    return;
                }

                _originalWord = value;
                OnPropertyChanged();
            }
        }

        public TranslateWord FinalWord
        {
            get => _finalWord;
            set
            {
                if (_finalWord == value)
                {
                    return;
                }

                _finalWord = value;
                OnPropertyChanged();
            }
        }

        public TranslateControlViewModel()
        {
            Languages = Enum.GetValues(typeof(TranslateLanguages)).Cast<TranslateLanguages>();
        }

        public async Task OperateTranslation() 
            => FinalWord = 
                await Translate(
                    new TranslateWord(OriginalWord),
                    ChosenLanguage);

        private async Task<TranslateWord> Translate(
            TranslateWord word = null,
            TranslateLanguages? targetLanguage = null)
        {
            var result = new TranslateWord("");
            var taskFactory = new TaskFactory();
            var model = new TranslateControlModel();

            //if (word.Language == null)
            //{
            //    result = await taskFactory.StartNew(() => model.Detect(word));
            //}
            if (targetLanguage != null)
            {
                result = await taskFactory
                    .StartNew(() => model
                                  .Translate(word, (TranslateLanguages) targetLanguage));
            }

            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}