   M S B A M L   `   `   `  ����  ListViewWPF    ListViewWPF.AddItemWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AddItemWindow��5   	   $	��320��6   $	��305��6,    � 
ResizeMode$ NoResize=�68    � WindowStartupLocation$ CenterScreen=�6N   .��5      �  � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � ColumnDefinitions 5
   
   �� 5      $��* �6   .+�5   
   �� -   5        $��txtBoxAddName��5      $��24��6'   $	��150��63   $��0,0,100,120q�6?   $��0��6T   �� 5   
   -   5        $��txtBoxAddAge��5      $��24��6&   $	��150��62   $��	0,0,100,0q�6>   $��0��6Q   �� 5   
   -   5        $��	labelName��5      $��Name:��6!   $��50��61   $��30��6<   $��0,0,200,160q�6H   $��0��6]   �� 5   
   -   5        $��labelAge��5      $
��Age:��6    $��35��6/   $��30��6:   $��
0,0,215,40q�6F   $��0��6Z   �� 5   
   $��Right=�6   $��70��6,   $��70��67   $��
0,0,20,110q�6C   $��0��6W   $��Image/logo.png��6d   �� 5   
   -   5        $��21��5      $��69��6   $��Add Item��6(   $��	0,110,0,0q�6;   $��0��6N   6[   �� 5   
   $��0��6   $��	0,190,0,0q�6!   $��2��65   �� 5   
   $��1��6   $��20,2,0,0q�6!   $��17(�63   $
��Bold"�6A   $��ST MicroSquare)�6S   
Counter:6y   �� 5   
   $��1��6   $��
230,65,0,0q�6!   $��11(�65   $��Italic$�6C   
��� � �Have Fun :)6v   �� 5   
   -   5        $��CounterLabel��5   @   $��1��6   $�� ��6   $	��100��6(   $��50��64   $��15(�6T   $��	64,0,0,10q�6b   $
��Bold"�6u   $��MATTEROFFACT)�6�   $��Center=�6�   �� 5   
   -   5        $��21��5      $��69��6   $��Hit ME!!��6(   $��0,30,0,0q�6;   $��1��6]   5      5      