   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFApp.ViewWPFApp.View  5   	       WPFApp.View.HistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFApp.View     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ HistoryWindow��5	   	   $	��450��6   $	��800��6,   ���	#FFE2E2E2 � 	Resources 5       �� 
TargetType �� Property �� Value3  -System.Windows.Media.Effects.DropShadowEffect   Color   	Direction   ShadowDepth	   Opacity��%�  '��       '�� �     '�� �    �� 5   
   " ��6   .�5      ��  � ��
 �   �6+   �� 5       � ��$ Segoe UI)�6+   �� 5       � ��$ 14(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$ Center=�6;   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 16(�6)   �� 5       � �� �	#FFC116456+   �� 5       � ��
 �����6+   �� 5       � ��$ 40��6'   5      �� 5   
   " ��6   .�5      ��  � ��$ Segoe UI)�6+   �� 5        � ��$ 14(�6)   �� 5!       � ��$	 5,2q�6(   �� 5"       � ��$ 10q�6'   �� 5#       � �� �	#FFC116456+   �� 5$       � ��
 �����6+   �� 5%       � ��
 ���� 6,   �� 5&       �@�Cursor$
 Hand��6'   �� 5'       � ��$ 30��6'   �� 5(       � ��$
 Bold"�6+   �� 5)       �@J�Effect 5*        5+      $ Black��6'   $	 320Q�65   $ 5Q�6E   $		 0.5Q�6U   5-      5.      5/      .��51      � $��20q�6   .+�52   
   �� -   5        
 ��Name$
 BookingListView��52      $	��690��6,   
������ 
�������$	��Top=�6e    �� View 53      �� 54      .P�55      �� $��Booking Date��6%    �� Width$	 230��6h    �� DisplayMemberBinding 6;   �� *BookingDate+6h   �� 56      $��Total Price��6%   $	 230��6f    6:   �� *
TotalPrice+6f   �� 57      $��Booking Status��6%   $	 230��6l    6=   �� *BookingStatus+6l   58      5:      �� 5;   
   -   5         ��Name$ Logout��5;      $��LOGOUT��6!   $��Right=�62   $	��Top=�6N   $��80��6f   $��	0,364,0,0q�6�   5<      5=      