   M S B A M L   `   `   `  ����G  CGestureMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GestureMakerGestureMaker  5   	       GestureMaker.AboutWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GestureMaker     5   	     � Title$  About��5   	   ���	#FF2D2D30 � 
ResizeMode$ NoResize=�6/    � WindowStartupLocation$ CenterOwner=�6E    � WindowStyle$
 None=�6i    � SizeToContent$ WidthAndHeight=�6|    � 	Resources 5	         FocusVisual �� Property �� Value �� StrokeDashArray	 J� SnapsToDevicePixels  Button.Static.Background
 �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground �� 
TargetType �� 
TargetType ��Name ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    '�� �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
	 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $
 	#00DDDDDD��6;   �� 5   
   $
 	#FF707070��67   �� 5   
   $
 	#00000000��6>   �� 5   
   $
 	#FFFFFFFF��6:   �� 5   
   $
 	#FFC4E5F6��6<   �� 5   
   $
 	#FF2C628B��68   �� 5   
   $
 	#FFF4F4F4��6=   �� 5   
   $
 	#FFADB2B5��69   �� 5   
   $
 	#FF838383��6=   �� 5   
   " ��6   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � �� �	#FFC8C8C86+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $
	 true��6�   ._�5)      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   #	 z	 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      5A      .��5B      � $	��400��6   $	��588��6   .+�5D   
   �� $��Stretch=�6   $	��150��65   $	��Top=�6B   $
��True��6Z   $��1,1,1,1q�6r   
�������$��
20,20,20,0q�6�   ��6�   Z� .��5E      �� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6X   $
��Wrap=�6   ���	#FFC8C8C8
���   ��� 6l   .�6q   Gesture Maker6�   ��

Copyright (c) 2020, Milan Egon Votrubec. All rights reserved.

This software is distributed under the "New BSD License" agreement:
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
- Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
- Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
- Neither the names of the University Stefan cel Mare of Suceava, University of Washington, nor University of Florida, nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
 
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ""AS IS"" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL Radu-Daniel Vatavu OR Lisa Anthony
OR Jacob O. Wobbrock BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT 
OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
SUCH DAMAGE.
            5Y      5Z      �� 5\   
   $��Stretch=�6   $	��150��65   $	��Top=�6B   $
��True��6Z   $��1,1,1,1q�6r   
�������$��20,190,20,0q�6�   ��6�   Z� .��5]      ��  preserve6X   $
��Wrap=�6   ���	#FFC8C8C8
���   ��� 6l   .�6q   ;9The $P Point-Cloud Recognizer (.NET Framework C# version)6�   ��
 
Copyright (c) 2012-2018, Radu-Daniel Vatavu, Lisa Anthony, and Jacob O. Wobbrock. All rights reserved.
                
Radu-Daniel Vatavu, Ph.D.
University Stefan cel Mare of Suceava
Suceava 720229, Romania
radu.vatavu@usm.ro
 
Lisa Anthony, Ph.D.
Department of CISE
University of Florida
Gainesville, FL 32611, USA
lanthony@cise.ufl.edu
 
Jacob O. Wobbrock, Ph.D.
The Information School
University of Washington
Seattle, WA 98195-2840
wobbrock@uw.edu
 
The academic publications for the $P, $P+, and $Q recognizers, and what should be used to cite them, are:
  	
    Vatavu, R.-D., Anthony, L. and Wobbrock, J.O. (2018).  
    $Q: A Super-Quick, Articulation-Invariant Stroke-Gesture
    Recognizer for Low-Resource Devices. Proceedings of 20th International Conference on
    Human-Computer Interaction with Mobile Devices and Services (MobileHCI '18). 
    Barcelona, Spain (September 3-6, 2018). New York: ACM Press.
    https://doi.org/10.1145/3229434.3229465

    Vatavu, R.-D. (2017). 
    Improving Gesture Recognition Accuracy on Touch Screens for Users with Low Vision.
    Proceedings of the 35th ACM Conference on Human Factors in Computing Systems (CHI '17).
    Denver, Colorado (May 2017). New York: ACM Press.
    http://dx.doi.org/10.1145/3025453.3025941

    Vatavu, R.-D., Anthony, L. and Wobbrock, J.O. (2012). 
    Gestures as point clouds: A $P recognizer for user interface prototypes. 
    Proceedings of the ACM International Conference on Multimodal Interfaces (ICMI '12). 
    Santa Monica, California (October 22-26, 2012). New York: ACM Press, pp. 273-280.
    https://doi.org/10.1145/2388676.2388732
 
This software is distributed under the ""New BSD License"" agreement:
 
Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
- Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
- Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
- Neither the names of the University Stefan cel Mare of Suceava, University of Washington, nor University of Florida, nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
 
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ""AS IS"" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL Radu-Daniel Vatavu OR Lisa Anthony
OR Jacob O. Wobbrock BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT 
OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
SUCH DAMAGE.
            5�      5�      �� 5�   
   -   5        $��OK��5�      $��Right=�6   $��	0,0,10,10q�6:   $��Bottom=�6M   $	��100��6~   ��6h   Z� 6�   5�      5�      