   M S B A M L   `   `   `  ����G  CGestureMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GestureMakerGestureMaker  5   	       GestureMaker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GestureMaker     5   	     � Title$&   Touch Controls - Gesture Creator��5   	   ���	#FF191919$��Disabled=�6I    � 
ResizeMode$ CanMinimize=�6}    � WindowStyle$ SingleBorderWindow=�6�    � SizeToContent$ WidthAndHeight=�6�    � 	Resources 5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background	 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground
 �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    '�� �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $	 	#00DDDDDD��6;   �� 5   
   $	 	#FF707070��67   �� 5   
   $	 	#00000000��6>   �� 5   
   $	 	#FFFFFFFF��6:   �� 5   
   $	 	#FFC4E5F6��6<   �� 5   
   $	 	#FF2C628B��68   �� 5   
   $	 	#FFF4F4F4��6=   �� 5   
   $	 	#FFADB2B5��69   �� 5   
   $	 	#FF838383��6=   �� 5   
   "
 ��6   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � �� �	#FFC8C8C86+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5)      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      5A      .��5B      �  � UseLayoutRounding$ False��6   ���	#FF2D2D30$	��500��6<   $	��300��6H   .+�5C   
   �� -   5         ��Name$ GestureImage��5C      $	��250��5H      $	��Top=�6   $	��250��5I      $��	10,10,0,0q�6   $
��Left=�61    � Cursor$	 Pen��5J      ��5K      �� 5L      $	 	#FF1D1B21��6"    �� Opacity$ 1Q�64   5N      �� 5O   
   $!��Add to Existing Gesture Set��6   $
��Left=�66   $��
265,10,0,0q�6Q   $	��Top=�6e   $	��225��6}   ���	#FFC8C8C8 � ToolTip$> 8Select the name of the existing Gesture and press Enter.��6�   �� 5P   
   -   5         ��Name$ ExistingGestures��5P      $
��Left=�6-   $��
265,35,0,0q�6H   $	��Top=�6\   $	��171��6t   $> 8Select the name of the existing Gesture and press Enter.��6�   �� 5Q   
   $��Add as New Gesture Set��6   $
��Left=�61   $��
265,60,0,0q�6L   $	��Top=�6`   $	��225��6x   ���	#FFC8C8C8$6 0Add the name of the new Gesture and press Enter.��6�   �� 5R   
   -   5         ��Name$ 
NewGesture��5R      $
��Left=�6&   $��
265,85,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $	��Top=�6i   $	��171��6�   $��22��6�   $6 0Add the name of the new Gesture and press Enter.��6�   �� 5S   
   $
��Left=�5T      $��
10,264,0,0q�6(   $	��Top=�6<   $��29��6T   $	��250��6`   $��WrapWithOverflow=�5U       �� 
LineHeight$ 1��6-   $��10(�6<   ��5V      �� 5W      $	 	#FFC8C8C8��6"   $	 0.5Q�64   $"Left Mouse Button to draw Strokes.�� 5Y   0   6<   " Right Mouse Button to Recognise.5[      �� 5\   
   -   5        $��Load Gestures��5\      $��Right=�6)   $��
0,268,64,0q�6E   $	��Top=�6Y   $	��171��6q   ���	#00DDDDDD���	#FFC8C8C8$��22��6�   �� 5]   
   -   5        $��About��5]      $��Right=�6!   $��	0,0,10,10q�6=   $��Bottom=�6P   $��49��6k   ���	#FFC8C8C8���	#00000000$��22��6�   �� 5_   
   $��1q�6   ���	#FF171717$��
0,170,10,0q�6=   $��90��6Q   $	��Top=�6]   $��Right=�6u   $	��225��6�   ._�5`      �� -   5         ��Name$ Results��5`      $
��Wrap=�6)   ���	#FF646464���	#FF2323236T   5a      �� 5b   
   -   5        $	��Add��5b      $��Right=�6   $��	0,35,10,0q�6;   $	��Top=�6N   $��49��6f   ���	#FFC8C8C8���	#00000000$��22��6�   �� 5c   
   -   5        $	��New��5c      $��Right=�6   $��	0,85,10,0q�6;   $	��Top=�6N   $��49��6f   ���	#FFC8C8C8���	#00000000$��22��6�   �� 5d   
   -	   5        $ Coordinates��5d      $
��Left=�6'   $��265,126,0,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�    J� RenderTransformOrigin$ 
0.25,0.002&�6�   5e      5f      