   M S B A M L   `   `   `  ����M  IStudentWorksSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:StudentWorksSearchStudentWorksSearch  5   	   #    StudentWorksSearch.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:StudentWorksSearch     5   	     � Title$  Авторизация��5   	   $	��210��6   $	��270��6*   $	��270��66   $	��270��6E   $	��210��6T   $	��210��6d   .��5	      �  � RowDefinitions 5
   
   �� 5      $��40 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��60 �6   �� 5      $	��200 �6   .+�5   
   �� $��2��6   
����d�._�5      �� $��Center=�6   $��Center=�63   $��16(�6P   *(Авторизация в систему6u   5      �� 5   
   $��1��6   $��Right=�6!   $��Center=�6>   $��14(�6Y   Логин:6o   �� 5   
   -   5        $��txtboxLogIn��5      $��1��6%   $��1��62   $��15 10q�6B   $��14(�6Q   6a   �� 5   
   $��2��6   $��Right=�6!   $��Center=�6>   $��14(�6Y   Пароль:6p   G� 5   
   -   5        $��passboxPass��5      $��2��6)   $��1��66   $��
15 10 15 0q�6F   $��14(�6Z   6j   �� 5   
   -   5        $��lblError��5      $��3��6$   $��2��61   $��Center=�6E   $��Center=�6c   $��11(�6~   
���  ��6�   �� 5!   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��2��6;   $
��22 5q�6O   $��Right=�6]   .+�5"      �� -   5        $��btnLogIn��5"      $��20 3 2 3q�6%   $��14(�67   $��90��6E   .��6g   
Войти6n   �� 5#      -   5        $��btnRegistration��5#      $��2 3 20 3q�6,   $��14(�6>   $��90��6L   .��6u   Регистрация6�   5$      5&      5'      