   M S B A M L   `   `   `  ����E  AGUIEksamen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GUIEksamen
GUIEksamen  5   	   ;"clr-namespace:GUIEksamen.ViewModelGUIEksamen.ViewModel  5   	   =#clr-namespace:GUIEksamen.ConvertersGUIEksamen.Converters  5   	       GUIEksamen.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GUIEksamen     5   	   8	viewModel"clr-namespace:GUIEksamen.ViewModel     5   	   :
converters#clr-namespace:GUIEksamen.Converters     5   	     � Title$  GUI Eksamen Vinter 2016��5
   	   $	��350��6)   $	��525��66    � 	Resources 5      .   (GUIEksamen.Converters.ImagePathConverter   ImagePathConverter  BackgroundBrush �� Color  ForegroundBrush �� 
TargetType  TextBoxToolbarStyle �� Property �� Value �� Triggers P� Property P� Value  BottonToolbarStyle3  -System.Windows.Media.Effects.DropShadowEffect	   ShadowDepth��%�  &	        &	      &	 3     &	 Q     '�� M    7  &	 &      5   
   6(   �� 5   
   $ Bisque��62   �� 5   
   $
 Blue��62   �� 5   
   " ��6   .�5      ��  � ��$
 10pt(�61   �� 5       � ��$
 Bold"�63   �� 5       � ��
 �����63    5      P� 5       �@J�	IsFocused . . �5      ��  � ��
 � ���6;   5      5      �� 5!   
   " ��6   .�5"      ��  � ��$
 Bold"�6+   �� 5#       � ��8   6+   �� 5$       � ��$	 Top=�62   �� 5%       � ��$
 Left=�64   �� 5&       � ��$ 92��6&   5'      �� 5*   
   " ��6+   �5+      �� 5,       � ��$ 32��6*   �� 5-       � ��
 ��  �6/   �� 5.       � ��$ 	ExtraBold"�6/   �� 5/       � ��$ 18(�6-   �� 50       � ��$ Arial)�6/    52      P� 53       �@J�IsMouseOver . . �54      ��  �@J�Effect 55        56      $	 2Q�6/   58      59      5;      5<      
 � DataContext
 5?      )   #GUIEksamen.ViewModel.ViewModelClass  5@   
   6%   .��5B      � -   5         �Name$ MyGrid��5B      #���  6    � ColumnDefinitions 5C   
   �� 5D      $
��100* �6   6.   �� 5E      $	��60* �6   6-   �� 5F      $	��45* �6   6-   �� 5G      $
��314* �6   6.    � RowDefinitions 5J   
   �� 5K      $	��20* �6   6+   �� 5L      $	��35* �6   6+   �� 5M      $	��30* �6   6+   �� 5N      $	��30* �6   6+   �� 5O      $	��34* �6   6+   �� 5P      $	��46* �6   6+   �� 5Q      $	��23* �6   6+   �� 5R      $	��23* �6   6+   �� 5S      $	��23* �6   6+   �� 5T      $	��23* �6   6+   �� 5U      $	��23* �6   6+   .+�5X   
   o� $��4��6   $��0��6#   .@�5Y      m� $��_File��6   .@�5Z      m� $��_Open��6    m� Command 6*   �� *OpenCommand+m� 5[      $��Save _As…��6    6.   �� *SaveAsCommand+�� 5\      m� 5]      $��E_xit��6    6+   �� *CloseAppCommand+5^      m� 5_      $��_Color��6   .@�5`      m� $��_Default��6    m� CommandParameter$ Default��6N    6-   �� *ColorCommand+6N   m� 5a      $��_Bisque��6   $ Bisque��6M    6,   �� *ColorCommand+6M   m� 5b      $��Light_Green��6   $ 
LightGreen��6Q    60   �� *ColorCommand+6Q   m� 5c      $��
_LightBlue��6   $ 	LightBlue��6P    6/   �� *ColorCommand+6P   m� 5d      $��Ghost_White��6   $ 
GhostWhite��6Q    60   �� *ColorCommand+6Q   5e      m� 5f      $��_Help��6   .@�5g      m� $��_About��6    6+   �� *AboutCommand+5h      5i      c� 5j   
   $��1��6   $��0��6   $��4��6/   $
��auto��6C   $��20(�5k      $
��Bold"�6    
�������.@�5n      ��  � ToolTip$ Move to previous picture��6   #��[ 5p      ��5o      �� *PreviusCommand+.��5q      �� $��images/left-arrow.png��6   $��Uniform=�67   5r      �� 5s      $ Move to next picture��6   #��[ 5u      ��5t      ��  �� Path$ NextCommand�.��5v      �� $��images/right-arrow.png��6   5w      �� 5y      $ Add a new picture��6   #��[ 5{      ��5z      �� *OpenCommand+.��5|      �� $��images/plus.png��6   5~      �� 5�      $ Delete selected picture��6   #��[ 5�      ��5�      �� *DeleteCommand+.��5�      �� $��images/delete.png��6   5�      �� 5�      $
��auto��6   $	��5,0q�6%   �� 5�      $��	Filename:��6   $��Center=�5�      $��2,0,2,0q�5�      $��12(�5�      �� 5�      -   5        $��NameOfPictures��5�      $��12(�5�      $ Name Of All pictures��5�      $	��120��5�      #��[ 5�      .��6N   5�      �� 5�      $ Rename the files��6   #��[ 5�      ��5�      �� *SaveAsCommand+��68   �� *Text+ �� ElementName$ NameOfPictures��.��5�      �� $��images/save.png��6   $��Uniform=�61   5�      5�      �� 5�   
   -   5        $��ImageDisplayer��5�   ]   $��0��6   $��3��6    $��3��64   $��4��6A   $��5q�6R   ��6t   �� *CurrentDataClass+ �� 	Converter# [  6�   &   System.Windows.Controls.DataGrid  5�   
   -   5        $��DgridDataClass��5�      $ �� IsSynchronizedWithCurrentItem$
 TrueY�5�      $��2��5�      $��8��5�      $��3��5�      $��9q�5�         
IsReadOnly .    MinRowHeight$ 12Q�5�      ��5�      ��  �� SelectedIndex 5�      �� $ CurrentIndex� �� SelectedItem 5�      �� $ CurrentDataClass�5�      �� 5�   
   $��7��6   $��0��6"   $��3��62   .+�5�   
   �� $ Move to previous Picture��6   #��[ 5�      ��5�      �� *PreviusCommand+.��5�      �� $��Images/left-arrow.png��6   $��Uniform=�67   5�      �� 5�   
   $ Move to next Picture��6   #��[ 5�      ��5�      �� $ NextCommand�.��5�      �� $��Images/right-arrow.png��6   $��Uniform=�68   5�      5�      �� 5�   
   $��Stretch=�6   $��0��62   $��10��6B   $��4��6P   ��5�      �� 5�      .R�5�      �  5�      �� 5�      $	��100 �6/   6=   �� 5�      �� 5�      $��153.6 �6/   6?   5�      5�      .@�5�      �� $��0��6   .��5�      �� $��Pictures Count:��6   5�      �� 5�      $��1��6   .��5�      �� $��40��68   ��6   �� $ Count�68   5�      �� 5�      -   5        $��SbiDateTime��5�      $��2��6/   .��5�      �� -   5        $��SpClock��5�   6    �� Orientation$ 
Horizontal=�6   .+�5�      �� -   5        $��TblkDate��5�   -   $	��4,0q�6    ��6=   �� $
 Date��� 5�      -   5        $��TblkTime��5�   -   $	��4,0q�6    ��6=   �� $
 Time�5�      5�      5�      5�      5�      