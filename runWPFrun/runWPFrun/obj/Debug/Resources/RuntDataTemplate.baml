   M S B A M L   `   `   `  ����D  @runWPFrun, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:runWPFrun	runWPFrun  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089J FWpfAnimatedGif, Version=1.4.14.0, Culture=neutral, PublicKeyToken=null  �� MergedDictionaries �� Source �� DataType    runWPFrun.RacePerson � 	Resources   Key �� 
StartPoint �� EndPoint � Color � Offset3   -runWPFrun.RaceProgressIndicatorWidthConverter ��Name  RunPitBorderStyle	 �� ElementName
 �� Path �� Orientation ��Name  RaceInProgressBrush �� RadiusX �� RadiusY  	WidthConv `� 	Converter"  WpfAnimatedGif.ImageBehavior   RepeatBehavior   AnimatedSource ��Name �� Triggers ^� 
Conditions �� Binding �� Value �� 
TargetName  FinishedBrush �� Value �� Property N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions  �� Value! �� Binding  WinnerBrush�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      !localclr-namespace:runWPFrun  5      ,gif"http://wpfanimatedgif.codeplex.com  5        5	      �� 5
   
   $ RunPitBorderStyle.xaml?�6   %�  (��       5      *,  +)7  7  7  7  7  �� 6   "   6    5   
   ���� 5      RaceInProgressBrush  $ 0,0.5&�6>   $ 1,0.5&�6Q   .��5      � $ 	#1100CC22��6   $ 0Q�61   � 5      $ 	#FFDA3737��6   $
 0.97Q�61   � 5      $ 	#FFDA3737��6   $ 0.999Q�61   � 5      $ #FF0000��6   $ 1Q�6/   5      �� 5      FinishedBrush  $ 0.5,0&�68   $ 0.5,1&�6K   .��5      � $ 	#44FF0000��6   $	 0.1Q�61   � 5      $ 	#11FF0000��6   $	 0.9Q�61   5      �� 5      WinnerBrush  $ 0.5,0&�66   $ 0.5,1&�6I   .��5      � $
 Gold��6   $	 0.1Q�6,   � 5      $ 	#FFFFFF88��6   $	 0.9Q�61   5        5       	WidthConv  68   5!      .R�5#   
   �� $ racePit��6   8��  ._�5$      � ��6   �� $	 racePit��$
 ActualWidth�.+�5%      �� $ 
Horizontal=�6   .+�5'      �� $ progressIndicator��6    8�� $
��Left=�5)      $ 8��5*      $ 8��5+      $��1q�5,      ��50      `� 51      8  .1�52   "   �� $
 PercentComplete�6*   �� 53   "   $	 racePit��6*   $
 ActualWidth�6@   54      56      �� 59      $
 100x��6   $ GIF.gif��5:      $��60��5;      $��80��6(   5<      �� 5=      $ 
personName��6   $	��6,0q�6G   $��Center=�6T   
���������60   �� *Name+6o   5>      5?       5A   
   ^� 5C       5D      �� 5E       6    �� *
IsFinished+ True6?   �� 5F       6    �� *
IsWinner+	 False6=   .0�5I      �� $ progressIndicator��6   8   � ��6H   �� 5J      $ 
personName��6    � ��$ Center=�6P    5M      �� 5N      .��5O      �� .��5P      W� $ racePit��6.   $ Opacity�6N   $	 0.6X�6r   $ 0:0:0.75D�6{   5Q      5R       5T      �� 5U      .��5V      �� .��5W      W� $ racePit��6.   $ Opacity�6N   $ 1X�6r   $ 0:0:0.25D�6y   5X      5Y      5[      �� 5^      $
  True��67   ! 6   �� *
IsWinner+.a�5_      �� $ progressIndicator��6   8   � ��6H   �� 5`      $ 
personName��6    � ��
 �   �6G   �� 5a      $ 
personName��6    � ��$
 Bold"�6G   �� 5b      $ 
personName��6    � ��$ Center=�6P   5d      5f      5g      