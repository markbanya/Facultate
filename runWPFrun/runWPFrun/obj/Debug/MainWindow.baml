   M S B A M L   `   `   `  ����D  @runWPFrun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:runWPFrun	runWPFrun  5          runWPFrun.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   #localclr-namespace:runWPFrun  5        � Title$  The Olympics��5      
�������$	��710��5      $	��710��6    � WindowStartupLocation$ CenterScreen=�5	      $��13(�5
      .��5      �  J� RenderTransformOrigin$ 2.319,0.526&�6   ��5   
   �� 5       �� ImageSource$ Resources/Background.jpg��6    �� Opacity$
 0.75Q�6@    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6    � 	Resources 5   
    �� MergedDictionaries �� Source�� 5       5      �� 5      $% Resources/RuntDataTemplate.xaml?�6)   %    5!      .+�5%   
   �� -   5        	 ��Name$	 	raceTrack��5%      $��0��5&      $��Stretch=�5'      $��8q�5(      $��Center=�5)      �� 5-   
   $��1��6   
���   �$��1q�62   
 �� CornerRadius$
 8��6F   $
��12,4q�6W   ��5/      �� 50       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   $	 0.8Q�6J   .��51      �  � Color$ 	#FFD6DA82��6#    � Offset$ 0Q�65   � 52      $ 	#FFF0FF58��6#   $	 0.7Q�65   � 53      $ Yellow��6#   $
 0.95Q�62   � 54      $ #EEEEEE��6#   $ 1Q�63   55      ._�58      � .+�59      �� $
��10,4q�6   $��Center=�6*   �� 5:      -   5         ��Name$ lnkStartNewRace��5:      $
��Bold"�66   .��5;      � .+�5<   
   �� 
���  ��Start6,   �� 5=   
   
��� ���New6-   �� 5>   
   
����  �Game6,   5@      5A      5D      5E      5F      5G      5I      