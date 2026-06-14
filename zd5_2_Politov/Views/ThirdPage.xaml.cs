using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd5_2_Politov.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdPage : ContentPage
    {
        // Переменная для хранения максимального выбранного пользователем значения
        private double maxUserValue = 0;
        private Random _random = new Random(); // Генератор случайных чисел
        public ThirdPage()
        {
            InitializeComponent();
        }

        // Отслеживаем движение ползунка и фиксируем исторический максимум
        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue > maxUserValue)
            {
                maxUserValue = e.NewValue; // Запоминаем рекордное значение
            }
        }

        // Клик по любой строчке: записываем выбор и подсвечиваем её зеленым
        private void OnItemClicked(object sender, EventArgs e)
        {
            var clickedLabel = (Label)sender;

            // Записываем выбор в шапку
            SelectedTariffLabel.Text = clickedLabel.Text;

            // Сбрасываем все строчки обратно в белый цвет
            Lbl1.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl1.TextColor = Color.FromHex("#2c3036");
            Lbl2.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl2.TextColor = Color.FromHex("#2c3036");
            Lbl3.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl3.TextColor = Color.FromHex("#2c3036");
            Lbl4.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl4.TextColor = Color.FromHex("#2c3036");

            // Выбранную строчку красим в красный, как Sign in
            clickedLabel.BackgroundColor = Color.FromHex("#e74c3c");
            clickedLabel.TextColor = Color.FromHex("#FFFFFF");

            // Плавное закрытие меню
            DropdownMenuFrame.IsVisible = false;
            BackgroundOverlay.IsVisible = false;

        }

        // Раскрытие/закрытие меню при тапе по красной шапке
        private void OnDropdownHeaderClicked(object sender, EventArgs e)
        {
            bool isVisible = !DropdownMenuFrame.IsVisible;
            DropdownMenuFrame.IsVisible = isVisible;
            BackgroundOverlay.IsVisible = isVisible; // Показываем или скрываем фон для клика мимо
        }

        private void OnBackgroundTapped(object sender, EventArgs e)
        {
            DropdownMenuFrame.IsVisible = false;
            BackgroundOverlay.IsVisible = false; // Прячем оверлей
        }

        // Кнопка BUTTON: базовый вывод данных день + якрость эффектов
        private async void OnStaticClicked(object sender, EventArgs e)
        {
            if (SelectedTariffLabel.Text == "Какой сегодня день?...")
            {
                await DisplayAlert("Внимание", "Пожалуйста, выберите объект из списка!", "OK");
                return;
            }

            string selectedDay = SelectedTariffLabel.Text;
            int currentSliderValue = (int)EffectsSlider.Value;

            ResultLabel.Text = $"День: {selectedDay}\nЯркость эффектов: {currentSliderValue}%";
        }

        // Кнопка STATIC: расширенный текст + выбранный день + время + процент опасности + процент яркости
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (SelectedTariffLabel.Text == "Какой сегодня день?...")
            {
                await DisplayAlert("Внимание", "Сначала выберите объект и нажмите BUTTON", "OK");
                return;
            }

            string selectedDay = SelectedTariffLabel.Text;
            int peakValue = (int)maxUserValue;

            // Расчет случайного процента опасности и получение времени
            int dangerPercent = _random.Next(0, 101); // число от 0 до 100
            string currentTime = DateTime.Now.ToString("HH:mm:ss");

            // Формируем расшифровку
            string advancedText = "";
            switch (selectedDay)
            {
                case "Прекрасный день": advancedText = "Система работает стабильно, ограничений нет."; break;
                case "Хороший день": advancedText = "Стандартный режим энергопотребления."; break;
                case "Плохой день": advancedText = "Рекомендуется снизить фоновые анимации."; break;
                case "Ужасный день": advancedText = "Критический режим! Включите защиту глаз."; break;
            }

            //Выбранный день
             selectedDay = SelectedTariffLabel.Text;

            // Формируем итоговый многострочный текст
            ResultLabel.Text = $"[Полный статус]\n" +
                               $"{advancedText}\n" +
                               $"День: {selectedDay}\n" +
                               $"Время замера: {currentTime}\n" +
                               $"Уровень опасности: {dangerPercent}%\n" +
                               $"Пик яркости эффектов : {peakValue}%";
        }

        // Кнопка СБРОС НАСТРОЕК: возвращает всё в исходное состояние
        private void OnResetClicked(object sender, EventArgs e)
        {
            // Сброс дропдауна
            SelectedTariffLabel.Text = "Какой сегодня день?...";
            DropdownMenuFrame.IsVisible = false;

            // Возвращаем строчкам стандартный белый цвет при общем сбросе
            Lbl1.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl1.TextColor = Color.FromHex("#2c3036");
            Lbl2.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl2.TextColor = Color.FromHex("#2c3036");
            Lbl3.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl3.TextColor = Color.FromHex("#2c3036");
            Lbl4.BackgroundColor = Color.FromHex("#FFFFFF"); Lbl4.TextColor = Color.FromHex("#2c3036");

            EffectsSlider.Value = 0;         // Сброс ползунка
            maxUserValue = 0;               // Сброс пикового значения в памяти
            ResultLabel.Text = "Ожидание выбора..."; // Сброс окна вывода

            // Выключаем все переключатели
            Switch1.IsToggled = false;
            Switch2.IsToggled = false;
            Switch3.IsToggled = false;
            Switch4.IsToggled = false;
            Switch5.IsToggled = false;
            Switch6.IsToggled = false;

            // Возвращаем всем шарикам белый цвет после сброса
            Switch2.ThumbColor = Color.FromHex("#FFFFFF");
            Switch4.ThumbColor = Color.FromHex("#FFFFFF");
            Switch6.ThumbColor = Color.FromHex("#FFFFFF");

            PageRoot.BackgroundColor = Color.AliceBlue; // Возвращаем серый фон страницы
        }

        //  Логика смены фона при переключении свитчей
        private void OnSwitchToggled(object sender, ToggledEventArgs e)
        {
            var sw = (Switch)sender;

            // В случае включения свитчей
            if (!e.Value)
            {
                // Все темные свитчи при выключении гарантированно получают БЕЛЫЙ шарик
                if (sw == Switch2 || sw == Switch4 || sw == Switch6)
                {
                    sw.ThumbColor = Color.FromHex("#FFFFFF");
                }
                else // Розовые свитчи при выключении тоже остаются с белым шариком
                {
                    sw.ThumbColor = Color.FromHex("#FFFFFF");
                }

                PageRoot.BackgroundColor = Color.AliceBlue; // Возврат к стандартному серому фону экрана
                return;
            }

            // В случае включения свитчей (Прописываем индивидуальные цвета шариков и фонов экрана)
            if (sw == Switch1)
            {
                PageRoot.BackgroundColor = Color.FromHex("#FFF0F2"); // Нежно-розовый фон экрана
            }
            else if (sw == Switch2)
            {
                sw.ThumbColor = Color.FromHex("#FF4D6D"); // Розовый шарик при включении темного свитча
                PageRoot.BackgroundColor = Color.FromHex("#E1F5FE"); // Светло-небесный фон экрана
            }
            else if (sw == Switch3)
            {
                PageRoot.BackgroundColor = Color.FromHex("#E8F5E9"); // Мягкий мятный фон экрана
            }
            else if (sw == Switch4)
            {
                sw.ThumbColor = Color.FromHex("#FF4D6D");
                PageRoot.BackgroundColor = Color.FromHex("#F3E5F5"); // Легкий сиреневый фон экрана
            }
            else if (sw == Switch5)
            {
                PageRoot.BackgroundColor = Color.FromHex("#FFF3E0"); // Теплый персиковый фон экрана
            }
            else if (sw == Switch6)
            {
                sw.ThumbColor = Color.FromHex("#FF4D6D");
                PageRoot.BackgroundColor = Color.FromHex("#E0F2F1"); // Глубокий бирюзовый фон экрана
            }
        }
    }
}