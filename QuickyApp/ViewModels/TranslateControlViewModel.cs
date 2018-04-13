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

        private TranslateLanguages _chosenTargetLanguage;

        private TranslateWord _finalWord;
        private List<object> _languages;
        private string _originalWord;

        public TranslateControlViewModel()
        {
            Array values = Enum.GetValues(typeof(TranslateLanguages));
            Languages = values
                        .Cast<object>()
                        .ToList();

            Languages.Insert(0, "Detect language");
        }

        public List<object> Languages
        {
            get => _languages;
            set
            {
                if (_languages == value)
                {
                    return;
                }

                _languages = value;
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

        public TranslateLanguages ChosenTargetLanguage
        {
            get => _chosenTargetLanguage;
            set
            {
                if (_chosenTargetLanguage == value)
                {
                    return;
                }

                _chosenTargetLanguage = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async Task<TranslateWord> OperateTranslation()
            => FinalWord =
                await Translate(
                                new TranslateWord(OriginalWord),
                                ChosenTargetLanguage);

        private async Task<TranslateWord> Translate(TranslateWord word = null,
                                                    TranslateLanguages? targetLanguage = null)
        {
            if (word == null)
            {
                word = new TranslateWord(OriginalWord);
            }

            if (targetLanguage == null)
            {
                targetLanguage = ChosenTargetLanguage;
            }

            var result = new TranslateWord("");
            var taskFactory = new TaskFactory();
            var model = new TranslateControlModel();

            //if (word.Language == null)
            //{
            //    result = await taskFactory.StartNew(() => model.Detect(word));
            //}
            //if (word//Language != null)
            {
                result = await taskFactory.StartNew(() => model.Translate(word, (TranslateLanguages) targetLanguage));
            }

            return result;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}