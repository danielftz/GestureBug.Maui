using System.Diagnostics;

namespace GestureBug
{
    public class BugPage : ContentPage
    {
        public BugPage()
        {

            CombinedButton combined;

            TapGestureRecognizer CombinedTap = new();
            CombinedTap.Tapped += (s, e) =>
            {
                Debug.WriteLine("Combined Tapped");
            };

            Content = combined = new CombinedButton()
            {
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            combined.GestureRecognizers.Add(CombinedTap);            
        }
    }

    public class CombinedButton : Grid
    {

        public CombinedButton()
        {
            AddRowDefinition(new RowDefinition());
            AddColumnDefinition(new ColumnDefinition());
            BackgroundColor = Colors.Red;
           
            //TODO: if frame is Frame, Tap will not register
            ContentView frame;
            this.Add(new GraphicsView
            {
                //TODO: if InputTransparnet is set to false, Tap will not register
                InputTransparent = true,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Drawable = new Circle()
            }, 0, 0);


            //TODO: if frame is Frame, Tap will not register
            this.Add(frame = new ContentView
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = Colors.Orange,
            });



            frame.Content = new Image()
            {
                Source = "lock_test.png",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Background = Colors.Yellow,
            };
        }
    }

    public class Circle : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Colors.Blue;
            canvas.FillCircle(dirtyRect.Center, dirtyRect.Width/2);
        }
    }
}