   M S B A M L   `   `   `  ����C  ?OOP_Lab1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:OOP_Lab1.Controls.VehiclesOOP_Lab1.Controls.Vehicles  5      0    *OOP_Lab1.Controls.Vehicles.TowerTankEditor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:OOP_Lab1.Controls.Vehicles     5      -   5        5   /OOP_Lab1.Controls.Vehicles.VehicleEditorControl   Name$  UserControl��5	      .��5
      � -   5        $��mainGrid��5
       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��Right=�61   $��Center=�6M   $
��10pxq�6h   $
��20px(�6v   Engine6�   �� 5   
   -   5        $��Engine��5      $��30��6!   $��Center=�6-   $��0��6H   $��1��6U    �� DisplayMemberPath$
 Name��6�    �� SelectedItem 6e   �� *Engine+��6�   �� *	Engines+ �� ElementName$ UserControl��5      �� 5   
   $��1��6   $��0��6!   $��Right=�61   $��Center=�6M   $
��10pxq�6h   $
��20px(�6v   Tracks6�   �� 5    
   -   5        $��Tracks��5       $��30��6!   $��Center=�6-   $��1��6H   $��1��6U   $
 Name��6�    6e   �� *Tracks+��6�   �� *Tracks+$ UserControl��5"      �� 5$   
   $��2��6   $��0��6!   $��Right=�61   $��Center=�6M   $
��10pxq�6h   $
��20px(�6v   Name6�   �� 5%   
   -   5        $��TankDestroyerName��5%      $��2��6+   $��1��68   $
��Left=�6H   $��200px��6c   $
��50px��6q   $
��10pxq�6   ��6�   �� *Name+6�   �� 5'   
   $��3��6   $��0��6!   $��Right=�61   $��Center=�6M   $
��10pxq�6h   $
��20px(�6v   Weight6�   �� 5(   
   -   5        $��Weight��5(      $��3��6    $��1��6-   $
��Left=�6=   $��200px��6X   $
��50px��6f   $
��10pxq�6t   ��6�   �� *Weight+6�   �� 5*   
   $��4��6   $��0��6!   $��Right=�61   $��Center=�6M   $
��10pxq�6h   $
��20px(�6v   Price6�   �� 5+   
   -   5        $��Price��5+      $��4��6   $��1��6,   $
��Left=�6<   $��200px��6W   $
��50px��6e   $
��10pxq�6s   ��6�   �� *Price+6�   �� 5-   
   $��5��6   $��0��6!   $��Right=�61   $��Center=�6M   $
��10pxq�6h   $
��20px(�6v   Gun6�   �� 5.   
   -   5        $	��Gun��5.      $��30��6   $��Center=�6*   $��5��6E   $��1��6R   $
 Name��6    6b   �� *Gun+��6�   �� *Guns+$ UserControl��50      �� 52   
   $��6��6   $��0��6!   $��Right=�61   $��Center=�6M   $
��10pxq�6h   $
��20px(�6v   Tower6�   �� 53   
   -	   5        $��Tower��53      $��30��6    $��Center=�6,   $��6��6G   $��1��6T   $
 Name��6�    6d   �� *Tower+��6�   �� *Towers+$ UserControl��55      �� 57   
   -
   5        $
��Save��57      $��100px��6   $
��40px��6+   $��20(�69   $��7��6G   $��1��6T   $��Center=�6d   $��Center=�6   ��6�   �� *SaveCommand+$ UserControl����6�   �� *ModifiedTowerTank+$ UserControl��.��6  Save6#  59      5:      