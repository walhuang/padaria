   M S B A M L   `   `   `  ����B  >Padaria, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PadariaPadaria  5   	       Padaria.JanelaVerComandas   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Padaria     5   	   -   5          � Title$,  &Ver Comandas - Sistema Padaria Cremosa��5   	   $	��720��68   $
��1280��6E   .��5	      � ���	#FF3F978F.+�5   
   �� -   5         ��Name$ btnSair��5      $��Ok��6"   $
��Left=�6/   $��534,530,0,0q�6J   $	��Top=�6_   $��96��6w   $��37��6�   ���	#FFE3EDF5 J� RenderTransformOrigin$ 0.115,0.351&�6�    � Cursor$
 Hand��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgVerComandas��5         AutoGenerateColumns .  $
��Left=�6F   $	��197��6a   $��333,170,0,0q�6n   $	��Top=�6�   $	��812��6�   ���	#FFB8C6D1   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Data do Pagamento��6G   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *DataPagamento+6G     5      $ Código Comanda��6C   	   
IsReadOnly	 .  6%   �� *	ComandaId+6[     5      $ nº da Compra��6B   	 .  6%   �� *
CompraId+6X     5      $ 
Valor Pago��6C    6%   �� *	ValorPago+6C     5      $ Troco��6D    6%   �� *
ValorTroco+6D     5      $ Preço Total da Compra��6D    6%   �� *
PrecoTotal+6D   5      �� 5   
   $��62,197,976,322q�6   $$��/Padaria;component/comanda.png��6(   $
��Fill=�6P   5      5      