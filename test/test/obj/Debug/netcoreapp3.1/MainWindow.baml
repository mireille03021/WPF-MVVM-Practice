   M S B A M L   `   `   `  ����I  EStockPriceRank, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:StockPriceRank.ViewModelStockPriceRank.ViewModel  5   	       StockPriceRank.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5vm&clr-namespace:StockPriceRank.ViewModel     5   	     � Title$  
MainWindow��5   	   $	��619��6   $	��563��6)    � DataContext 5	      ,   &StockPriceRank.ViewModel.MainViewModel  5
   
   .��5      � $��0,0,0,-5q�6    � ColumnDefinitions 5   
   �� 5      $
��554* �6   �� 5      $��3* �6   �� 5      $��6* �6   .+�5   
   �� -   5         ��Name$ listView��5      $
��Left=�6%   $	��Top=�6@   $	��334��6X   $	��517��6e   $��23,0,0,0q�6�   ��6q   �� *StockListView+ �� View 5      �� 5      -   5        gridView�� �� AllowsColumnReorder$
 true��5   -    �� ColumnHeaderToolTip$ Stock Infomation��6H   .P�5      �� $��股票名稱��6%    �� Width$	 100��63    �� DisplayMemberBinding 6?   �� *Name+�� 5      $��	成交價��6%   $	 100��62    6>   �� *
FinalPrice+�� 5      $��	開盤價��6%   $	 100��62    6>   �� *OpeningPrice+�� 5      $��	漲跌幅��6%   $	 100��62    6>   �� *QuoteChange+�� 5      $��	成交量��6%   $	 100��62    6>   �� *Volume+5      5      �� 5   
   -   5        	 ��Name$	 slider��5      
 � Maximum$

 3000Q�6!    � Minimum$ 10Q�60    �� TickFrequency$	 300Q�6=   $
��Left=�6v   $��
23,339,0,0q�6�   $	��Top=�6�   $	��300��6�   $��30��6�   $��Center=�6�   $��Center=�6�    �� TickPlacement$
 Both=�6   � Cursor$ Arrow��60   � Value 6Q   �� *RefreshMilliSecond+60  �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��328,339,0,0q�6>    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $��59��6�   $��30��6�   $��16(�6�   $��Center=�6�   $��Center=�6�   ${�False��6  ��6S   �� *RefreshMilliSecond+6  �� 5    
   -   5         ��Name$ button1��5       $��停止刷新��6"   $
��Left=�6R   $��105,374,0,0q�6m   $	��Top=�6�   $��44��6�   $��77��6�   ��61   �� *TimerDispose+6�   �� 5!   
   -   5         ��Name$ label��5!      $
��Left=�6B   $��480,339,0,0q�6]   $	��Top=�6r   $��30��6�   $��49��6�   ��6   �� *CheckFrequency+6�   �� 5"   
   -   5        $ button1_Copy��5"      $��開始刷新��6'   $
��Left=�6U   $��
23,374,0,0q�6p   $	��Top=�6�   $��44��6�   $��77��6�   ��66   �� *
TimerStart+6�   �� 5#   
   -   5        $ button��5#      $��更新刷新時間��6!   $
��Left=�6\   $��392,339,0,0q�6w   $	��Top=�6�   $��30��6�   $��83��6�   ��62   �� *ChangeUItimerInterval+6�   5%      5'      