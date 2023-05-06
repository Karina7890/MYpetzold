using System; 
using System.Windows;
using System.Windows.Input; 
using System.Windows.Media; 
namespace Petzold.VaryTheBackground { // цвет фона клиентчской области
public class VaryTheBackground : Window     {
SolidColorBrush brush = new  SolidColorBrush(Colors.Black);
[STAThread]       
public static void Main()         {  
Application app = new Application();             app.Run(new VaryTheBackground());         }  
public VaryTheBackground()         {             Title = "Vary the Background";             Width = 384;  
 Height = 384;             Background = brush;         }      
 protected override void OnMouseMove (MouseEventArgs args) // задает все три цветовые составляющие для получения одного
  {             double width = ActualWidth                 - 2 * SystemParameters .ResizeFrameVerticalBorderWidth;             
  double height = ActualHeight                 - 2 * SystemParameters .ResizeFrameHorizontalBorderHeight                 - SystemParameters.CaptionHeight;  
  Point ptMouse = args.GetPosition(this);  
   Point ptCenter = new Point(width / 2,  height / 2); // центр клиентнской области 
   Vector vectMouse = ptMouse - ptCenter;             double angle = Math.Atan2(vectMouse.Y,  vectMouse.X);
   Vector vectEllipse = new Vector(width  / 2 * Math.Cos(angle),                                             height  / 2 * Math.Sin(angle)); 
   Byte byLevel = (byte) (255 * (1 - Math .Min(1, vectMouse.Length /                                                            vectEllipse.Length))); // расстояние от центра клиентной области эллипса
   Color clr = brush.Color;  // класс браш позволяет динамически изменять цвет клиентской облсасти при каждлом измненении кисти
   clr.R = clr.G = clr.B = byLevel;
    brush.Color = clr;         }     } } 
 
