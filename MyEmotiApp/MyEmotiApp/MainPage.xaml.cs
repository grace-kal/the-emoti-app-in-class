namespace MyEmotiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEmojiBtnClicked(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                this.BackgroundColor = btn.BackgroundColor;

                MoodImage.Source = btn.Text switch
                {
                    "happy!" => "happy_emoji.png",
                    "cool!" => "cool_emoji.png",
                    "shy!" => "shy_emoji.png",
                    "angry!" => "mad_emoji.png",
                    "in love!" => "heart_eyes_emoji.png",
                    "sick!" => "sick_emoji.png",
                    "lucky!" => "money_face_emoji.png",
                    "awkward!" => "ugh_emoji.png",
                    _ => MoodImage.Source
                };
            }
        }
    }

}
