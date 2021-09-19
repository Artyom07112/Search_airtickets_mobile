using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Xamarin.Essentials;

namespace POL
{
    

    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class TabbedPage1 : TabbedPage
    {
        public List<News> news { get; set; }
        public List<Reus> reus { get; set; }
        public string News_New_york = "";
        public string News_Berlin = "";
        public string News_Moscow = "";
        public string News_Paris = "";
        public string News_Budapesht = "";
        public string News_Oslo = "";
        public string News_Brest = "";
        public string News_HongKong = "";
        public string News_Kobrin = "";
        public string News_Milan = "";

        public TabbedPage1()
        {
            InitializeComponent();
            Novosti();
           var news = new List<News>
           {
                new News{ Title="New York", Imagepath="New_york.jpg",New=News_New_york },
                new News{ Title="Berlin", Imagepath="Berlin.jpg",New=News_Berlin},
                new News{ Title="Moscow", Imagepath="Moscow.jpg",New=News_Moscow},
                new News{ Title="Paris", Imagepath="Bashn9.jpg",New=News_Paris},
                new News{ Title="Budapesht", Imagepath="budapesht.jpg",New=News_Budapesht},
                new News{ Title="Oslo", Imagepath="oslo.jpg",New=News_Oslo},
                new News{Title="Brest",Imagepath="Brest.jpg",New=News_Brest},
                new News { Title="HongKong", Imagepath="HongKong.jpg",New=News_HongKong},
                new News{ Title="Kobrin", Imagepath="Kobrin.jpg", New=News_Kobrin},
                new News{Title="Milan",Imagepath="Milan.jpg", New=News_Milan}
           };
            News1.ItemsSource=news;
          
        }
        public class News
        {
            public string Title { get; set; }
            public string New { get; set; } 
            public string Imagepath { get; set; }
            
            
        }
        public class Reus
        {
            public string ON { get; set; }
            public string IN { get; set; }
            public string Imageph { get; set; }
            public string Imagetp { get; set; }

        }
        private string filename = "GT.txt";
        private async void Button_Clicked(object sender, EventArgs e)
        {
            grid.IsVisible = true;
            string str = "";
            using (var stream = await FileSystem.OpenAppPackageFileAsync(filename))
            {
                using (var reader = new StreamReader(stream))
                {

                    str = reader.ReadToEnd();

                }
            }
            try
            {
                string[] massimage = { "Brest.jpg", "Berlin.jpg", "HongKong.jpg", "Kobrin.jpg", "Milan.jpg", "Moscow.jpg", "New_york.jpg" };
                string text1 = first.SelectedItem.ToString();
                string text2 = second.SelectedItem.ToString();
                string text3 = text1 + "-" + text2;
                string[] mass = str.Split(new char[] { ',' });
                // string[] massLow;
                string Image = "";
                string Image2 = "";
                foreach (var item in massimage)
                {
                    if (text1 + ".jpg" == item)
                    {
                        Image = item;
                    }
                    else if (text2 + ".jpg" == item)
                    {
                        Image2 = item;
                    }
                }



                var selectedTeams = from t in mass
                                    where t.StartsWith($"{text3}")
                                    select t;
                var reus = new List<Reus>
            {
                new Reus{ON=$"{text1}", IN=Convert.ToString(selectedTeams),Imageph=Image },
                new Reus{ON=$"{text2}", IN="",Imageph=Image2 }
            };
                List_air.ItemsSource = reus;
            }
            catch
            {
                await DisplayAlert("ОШИБКА", "Вы не ввели данные для поиска", "OK");    
            }
        }
        private void Novosti()
        {
            News_New_york = "Нью-Йорк — пожалуй, самый известный город в мире, в котором сосредоточены финансовые учреждения, многочисленные исторические и культурные достопримечательности, музеи, магазины, театры и многое другое. Это шумный и яркий город небоскребов и свободы, который многим знаком по обилию кинофильмов и фото, где действие разворачивается на его улицах. Здесь столько возможностей, сколько можно вообразить. ";
            News_Moscow = "Москва — столица и крупнейший город России. Сюда ведут многие пути и человеческие судьбы, с этим городом связано множество роковых и знаменательных событий истории, людских радостей и надежд, несчастий и разочарований и, разумеется, легенд, мифов и преданий. Москва — блистательный город, во всех отношениях достойный называться столицей. Здесь великолепные памятники архитектуры и живописные парки, самые лучшие магазины и высокие небоскребы, длинное метро и заполненные вокзалы. Москва никогда не спит, здесь трудятся с утра до поздней ночи, а затем веселятся до утра.";
            News_Berlin = "Берлин для россиян и народов стран СНГ – особый город. Здесь в мае 1945 года, после самой кровопролитной войны в истории, был повержен фашизм, поднято Знамя Победы. Город с большими амбициями, несостоявшаяся мировая столица, на 28 лет «перерезанная» так называемой Позорной стеной, – все эти титулы для современного Берлина давно стали частью истории. Сегодня у второго по численности населения города Евросоюза другие черты. Безусловно, суровое прошлое окончательно не забыто, но оно уже не так бросается в глаза, отчего облик столицы Германии только выиграл.";
            News_Budapesht = "Будапешт (Budapest) – столица и одновременно самый крупный город Венгрии. Из почти 10-миллионного населения этого неболjpgьшого государства в столице проживает почти 1,8 млн человек. По численности населения Будапешт находится в Европейском Союзе на 8 месте. Современный мегаполис – ведущий политический, экономический и культурный центр страны – раскинулся на берегах седовласого Дуная и занимает площадь 525,14 тыс. км².";
            News_Oslo = "Осло – столица Норвегии и крупный европейский город, раскинувший свои владения на северной оконечности одноименного фьорда и 40 прилегающих островах. Прагматичный, невероятно дорогой, по-скандинавски медлительный и знающий себе цену Осло уже давно и прочно обосновался в списке самых благополучных городов планеты, по уровню доходов на душу населения серьезно обогнав таких «олигархов», как швейцарский Цюрих и арабский Абу-Даби.";
            News_Paris = "Париж — столица Франции, самый красивый и элегантный город мира, символ любви и романтики, моды и изысканности. Нет такого человека, который не мечтал бы посетить Париж, увидеть ставшие хрестоматийными достопримечательности, окунуться в атмосферу раскованности, отдать должное французской кухне, побродить по красивым бульварам. В Париже есть всё, о чём мечтают путешественники, – многочисленные музеи с богатейшими коллекциями, отличный шоппинг, развлечения на любой вкус.";
            News_Brest = "Брест – уютный и радушный город с выдающейся историей, один из древнейших на территории Республики Беларусь. Он находится близ западных рубежей страны и является административным центром Брестской области. Издавна занимавший важнейшее место в культурной, торговой и политической жизни Побужья, Брест еще с XI века представлял собой предмет притязаний властителей окружавших его земель и в течение тысячелетия побывал в составе разных государств. Пережив немало нашествий и две мировые войны, город утратил многие памятники своей истории, но те, что сохранились, привлекают путешественников со всего мира. Одну только Брестскую крепость, главную достопримечательность города, ежегодно посещают более 700 тысяч туристов.";
            News_HongKong = "Гонконг — государство в государстве со своими законами, порядками и культурой. Это место встречи Запада и Востока, где высокие технологии соседствуют с традиционным укладом жизни, небоскрёбы — с рыбацкими деревушками, а чопорные торговые центры – с хаотичными плавучими рынками. Исторически Гонконг — бывшая колония Великобритании, а в настоящее время – специальный административный район Китая, поражающий темпами своего прогресса.";
            News_Kobrin = "Кобрин (белор. Кобрын), — город в Брестской области Белоруссии, административный центр Кобринского района. Четвёртый по количеству населения город в области(уступает Бресту, Барановичам и Пинску).По данным на 1 января 2020 года население города составило 52 600 человек ";
            News_Milan = "Милан – второй по величине город Италии, ее важный торговый, экономический и научный центр. Он расположен в северной части страны, в регионе Ломбардия, и делится на девять районов. Численность населения – чуть более миллиона человек, но эта цифра постоянно растет, ведь эти места привлекают возможностью получить престижную профессию или высокооплачиваемую работу.";

        }

        private async void News1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            News news = e.Item as News;
            if (news!=null)
            {
                await DisplayAlert( $"{news.Title} ", $"{news.New}", "OK") ;
            }

        }
       
        private async void Button_Clicked_plus(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(Kolvo_deti.Text);

            if (a<100)
            {
                Kolvo_deti.Text = Convert.ToString(a + 1);
                detiDop++;
                if (a >= 4)
                {

                    if (await DisplayAlert("", "Соболезнуем", "Оставить детей дома", "Продолжить") == true)
                    {
                        Kolvo_deti.Text = Convert.ToString(a = 0);
                        detiDop = 0;
                    }
                }
            }
            grid.IsVisible = true;
            Skidochka();
            Suuma();
            Suma_and_skidka();

        }
        public int detiDop = 0;
        public double Summa = 0;
        private void Button_Clicked_minus(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(Kolvo_deti.Text);
            if (a==0)
            {
                grid.IsVisible = false;
                DisplayAlert("Ошибка", "Ваше количесво не может быть отрицательное", "OK");
            }
            else
            {
                Kolvo_deti.Text = Convert.ToString(a - 1);
                detiDop--;
                if (Convert.ToInt32(Kolvo_deti.Text)==0)
                {
                    grid.IsVisible = false;
                }
            }
            Skidochka();
            Suuma();
            Suma_and_skidka();
        }

        private void Button_Clicked_bagazplus(object sender, EventArgs e)
        {
            int bag = Convert.ToInt32(Bagaz.Text);
            if (bag<100)
            {
                Bagaz.Text = Convert.ToString(bag + 10);
            }
            grid.IsVisible = true;
            Skidochka();
            Suuma();
            Suma_and_skidka();
        }
        private void Button_Clicked_bagazminus(object sender, EventArgs e)
        {
            int bag = Convert.ToInt32(Bagaz.Text);
            if (bag == 0)
            {
                grid.IsVisible = false;
                DisplayAlert("Ошибка", "Ваш багаж не может быть отрицательное", "OK");
            }
            else
            {
                Bagaz.Text = Convert.ToString(bag - 10);
                if (Convert.ToInt32(Bagaz.Text) == 0)
                {
                    grid.IsVisible = false;
                }
            }
            Skidochka();
            Suuma();
            Suma_and_skidka();
        }
        public double skidka = 0;
        private void Button_Clicked_CheckPromo(object sender, EventArgs e)
        {
            string[] promokodi = {"artyomtop","letileti","2020","kolledz" };
            foreach (string item in promokodi)
            {
                if (item==Promo.Text)
                {
                    Promo.TextColor = Color.Green;
                }
            }
            if (Promo.TextColor == Color.Green)
            {
                skidka=0.2;

            }
            else
            {
                Promo.TextColor = Color.Red;
            }
            Skidochka();
            Suuma();
            Suma_and_skidka();
        }
        private void Skidochka()
        {
            double sim = Convert.ToDouble(Kolvo_deti.Text);

            double zim = Convert.ToDouble(Bagaz.Text);
            double lol = 0;
            lol = ((sim * 500 + zim * 100) * skidka);
            Skidon.Text = "-"+Convert.ToString(lol);
        }
        private void Suuma()
        {
            double sim =Convert.ToDouble( Kolvo_deti.Text);
            double zim = Convert.ToDouble(Bagaz.Text);
            double lol = 0;
            
            if (skidka==0)
            {
                lol = (sim * 500 + zim * 100); 
            }
            else
            {
                lol = (sim * 500 + zim * 100)-((sim * 500 + zim * 100) * skidka) ;
            }
            
            OBZ.Text = Convert.ToString(lol);
        }
        private void Suma_and_skidka()
        {
            double sim = Convert.ToDouble(Kolvo_deti.Text);
            double zim = Convert.ToDouble(Bagaz.Text);
            Vivod.Text = Convert.ToString(sim*500+zim*100);


        }

        //public bool Okras()
        //{
        //    if ()
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}