   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFApp.ViewWPFApp.View  5   	       WPFApp.View.ReportWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFApp.View     5   	     � Left$	  130��5   	   
 � Top$	 150��6    � Title$ ReportWindow��5	   	   $	��800��6   $
��1100��6+   ���	#FFFAFAFA � 	Resources 5       �� 
TargetType   NavButtonStyle �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction	   ShadowDepth
   Opacity  LogoutButtonStyle&   System.Windows.Controls.DataGrid��%*  &	        &	 �    '      �� 5   
   " ��6   .�5      ��  � ��$ 80��6&   �� 5       � ��$ 35��6'   �� 5       � ��$ 0,10,0,0q�6'   �� 5       � �� �	#FFE8AE316+   �� 5       � ��
 �   �6+   �� 5       � ��
 ���� 6,   �� 5       � ��$
 Bold"�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       �@J�Effect 5        5      $ Black��6'   $	 320Q�65   $	 5Q�6E   $	
 0.3Q�6U   5      5      �� 5   
   " ��6   .�5      ��  � ��
 �  ��6+   �� 5        � ��$
 Bold"�6+   �� 5!       � ��
 ���� 6+   �� 5"       � ��
 ���� 6,   �� 5#       �@�Cursor$
 Hand��6'   �� 5$       � ��$ 70��6&   �� 5%       � ��$ 30��6'   5&      �� 5)   
   "  6   .�5*      ��  � ��$ Segoe UI)�6+   �� 5+       � ��$ 14(�6)   �� 5,       � ��$ 20q�6'   �� 5-       � ��
 �����6+   �� 5.       �@ RowBackground �	#FFFAFAFA6.   �� 5/        �@ AlternatingRowBackground �	#FFF2F2F269   �� 50       �@ GridLinesVisibility$
 None=�64   �� 51        �@ HorizontalGridLinesBrush �	#FFE8E8E869   �� 52       �@ VerticalGridLinesBrush �	#FFE8E8E867   53      54      .��56      �  � ColumnDefinitions 57   
   �� 58      $
��Auto �6   �� 59      $��* �6   .+�5=   
   �� -   5         ��Name$	 Nav��5=      $��0��6"    �� Orientation$ Vertical=�62   $��10q�6I   ���	#FFE2E2E2.+�5>      �� -   5        $��Report��5>      #��[  6A   �� 5?      -   5         ��Name$
 Room��5?      $
��Room��6#   #��[  6K   �� 5@      -   5        $ Custmer��5@      $��Customer��6&   #��[  6V   5A        5D   
   -   5        $��DataGrid��5D         AutoGenerateColumns$
 True��5E         
IsReadOnly$
 True��5F         CanUserSortColumns$
 True��5G      $��1��5H      $��20,20,20,60q�5I      �� 5L   
   -   5        $ Logout��5L      $��1��6!   $��LOGOUT��61   $��Right=�5M      $	��Top=�6-   #��[ 5N   &   $��	0,20,20,0q�5O      5P      5Q      