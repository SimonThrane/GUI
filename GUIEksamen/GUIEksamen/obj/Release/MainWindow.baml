   M S B A M L   `   `   `  ���� E  AGUIEksamen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GUIEksamen
GUIEksamen  ;"clr-namespace:GUIEksamen.ViewModelGUIEksamen.ViewModel  =#clr-namespace:GUIEksamen.ConvertersGUIEksamen.Converters      GUIEksamen.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:GUIEksamen     8	viewModel"clr-namespace:GUIEksamen.ViewModel     :
converters#clr-namespace:GUIEksamen.Converters       � Title$  GUI Eksamen Vinter 2016��$	��350��$	��525�� � 	Resources .   (GUIEksamen.Converters.ImagePathConverter   ImagePathConverter  BackgroundBrush �� Color  ForegroundBrush �� 
TargetType  TextBoxToolbarStyle �� Property �� Value �� Triggers P� Property P� Value  BottonToolbarStyle3  -System.Windows.Media.Effects.DropShadowEffect	   ShadowDepth��%r  &	        &	      &	      &	 '     '�� �     7  &	 ^      �� $ Bisque���� $
 Blue���� " ��.���  � ��$
 10pt(���  � ��$
 Bold"���  � ��
 ��  � P�  �@J�	IsFocused . . ���  � ��
 � �����  �@��CharacterCasing$ Upper=��� " ��.���  � ��$
 Bold"���  � ��8   ��  � ��$	 Top=���  � ��$
 Left=���  � ��$ 92���� " �����  � ��$ 32����  � ��
 ��  ���  � ��$ 	ExtraBold"���  � ��$ 18(���  � ��$ Arial)� P�  �@J�IsMouseOver . . ���  �@J�Effect   $	 2Q�
 � DataContext
 )   #GUIEksamen.ViewModel.ViewModelClass  .��� -    �Name$ MyGrid��#���   � ColumnDefinitions �� $
��100* ��� $	��60* ��� $	��45* ��� $
��314* � � RowDefinitions �� $	��20* ��� $	��35* ��� $	��30* ��� $	��30* ��� $	��34* ��� $	��46* ��� $	��23* ��� $	��23* ��� $	��23* ��� $	��23* ��� $	��23* �.+�o� $��4��$��0��.@�m� $��_File��.@�m� $��_Open�� m� Command �� *OpenCommand+m� $��Save _As…�� �� *SaveAsCommand+�� m� $��E_xit�� �� *CloseAppCommand+m� $��_Color��.@�m� $��_Default�� m� CommandParameter$ Default�� �� *ColorCommand+m� $��_Bisque��$ Bisque�� �� *ColorCommand+m� $��Light_Green��$ 
LightGreen�� �� *ColorCommand+m� $��
_LightBlue��$ 	LightBlue�� �� *ColorCommand+m� $��Ghost_White��$ 
GhostWhite�� �� *ColorCommand+m� $��_Help��.@�m� $��_About�� �� *AboutCommand+c� $��1��$��0��$��4��$
��auto��$��20(�$
��Bold"�
�������.@���  � ToolTip$ Move to previous picture��#��[ ���� *PreviusCommand+.���� $��images/left-arrow.png��$��Uniform=��� $ Move to next picture��#��[ ����  �� Path$ NextCommand�.���� $��images/right-arrow.png���� $ Add a new picture��#��[ ���� *OpenCommand+.���� $��images/plus.png���� $ Delete selected picture��#��[ ���� *DeleteCommand+.���� $��images/delete.png���� $
��auto��$	��5,0q��� $��	Filename:��$��Center=�$��2,0,2,0q�$��12(��� -   $��NameOfPictures��$��12(�$ Name Of All pictures��$	��120��#��[ .���� $ Rename the files��#��[ ���� *SaveAsCommand+���� *Text+ �� ElementName$ NameOfPictures��.���� $��images/save.png��$��Uniform=��� -   $��ImageDisplayer��$��0��$��3��$��3��$��4��$��5q����� *CurrentDataClass+ �� 	Converter# [  &   System.Windows.Controls.DataGrid  -   $��DgridDataClass��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��2��$��8��$��3��$��9q�   
IsReadOnly .    MinRowHeight$ 12Q�����  �� SelectedIndex �� $ CurrentIndex� �� SelectedItem �� $ CurrentDataClass��� $��7��$��0��$��3��.+��� $ Move to previous Picture��#��[ ���� *PreviusCommand+.���� $��Images/left-arrow.png��$��Uniform=��� $ Move to next Picture��#��[ ���� $ NextCommand�.���� $��Images/right-arrow.png��$��Uniform=��� $��Stretch=�$��0��$��10��$��4������ .R��  �� $	��100 ��� �� $��153.6 �.@��� $��0��.���� $��Pictures Count:���� $��1��.���� $��40������ $ Count��� -   $��SbiDateTime��$��2��.���� -   $��SpClock�� �� Orientation$ 
Horizontal=�.+��� -   $��TblkDate��$	��4,0q����� $
 Date��� -   $��TblkTime��$	��4,0q����� $
 Time�