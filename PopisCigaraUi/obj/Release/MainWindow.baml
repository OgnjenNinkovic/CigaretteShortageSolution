   M S B A M L   `   `   `  ���� H  DPopisCigaraUi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PopisCigaraUiPopisCigaraUi      PopisCigaraUi.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:PopisCigaraUi     -     �Name$  mainWin�� � Title$ 
MainWindow��$	��430��$	��430��$	��635��$	��635�� � 	Resources 2   ,PopisCigaraUi.GridViewRowBackgroundConverter   backgroundConverter  myItemStyle �� 
TargetType �� Property �� Value �� 	Converter �� RelativeSource  myHeaderTemplate  nazivTemplate �� TextAlignment	 �� Path  kolTemplate  barCodeTemplate  cenaTemplate��%�  &	        &	      7   &	 ?     &	 q     &	 �     &	     &	 [      �� " ��.���  � �� �� 8    �� *Self+�� .R�]� .+��� $��15(�$
��Bold"����� �� .R��� $	��300��$ Center=�$
��Bold"�$��12(����� $
	 Name��� .R��� $��50��$
��Bold"�$ Center=�$��12(����� $	 Kolicina��� .R��� $	��150��$
��Bold"�$ Center=�$��12(����� $	 Barcode��� .R��� $
��Bold"�$	��100��$ Center=�$��12(����� $
	 Cena�.��� 
 � RowDefinitions
 �� $	��44* ��� $	��30* ��� $
��259* ��� $	��50* �.+��� $��0�� �� Orientation$ 
Horizontal=�$��0,0,-0.4,0.2q�.+��� -    ��Name$ txtBar��$��0��$��10,0,5,0q�$
��Left=� �� TextWrapping$
 Wrap=�$�� �� �� TextAlignment$ Center=�$	��127��$��25��$��14(�$
��Bold"�$��
2147483640���� -    ��Name$ txtNaziv��$��0��$
��Wrap=�$ Center=�$�� ��$
��Bold"�$��18(�$��25�����	#FFA9FFF7$	��404��$��Stretch=��� -   $ txtKol��$��0��$
 Wrap=�$�� ��$��25��$��53��$��5,0,0,0q�$��
2147483641��$��Stretch=��� $��1��$ 
Horizontal=�.+��� -    ��Name$ label��$��1��$��10,0,0,0q�$��Fin manjak:��$��29��$
��Bold"�$��16(�$
��Left=�$	��100��$��Center=��� -   $ 	manjakTxt��$��1��$
��Wrap=�$
��Left=�$�� ��$
��Bold"�$��16(�$��Center=�$	��100��$��29��$��0,10,0,0q��� -   $ 
label_Copy��$��
Fin Visak:��$��29��$
��Left=�$��Center=�$
��Bold"�$��16(�$��82��$��	0,0,0,0.6q��� -   $ visakTxt��$��1��$
��Left=�$
��Wrap=�$�� ��$	��100��$��29��$��Center=�$
��Bold"�$��16(�$��0,10,0,0q��� -	   $ label_Copy1��$��1��$��Ukupno:��$
��Left=�$��29��$��Center=�$
��Bold"�$��16(�$��74��$��	0,0,0,0.6q��� -
   $ ukupanManjakTxt��$��1��$
��Left=�$
��Wrap=�$�� ��$	��100��$��29��$��Center=�$
��Bold"�$��16(�$��0,10,0,0q��� -    ��Name$ 
listManjak��$��2��$��10,9.8,9.6,11q�$	��240�� �� SelectionMode$ Extended=�#��[ ����  �� View �� ��. P��� $��Barkod�� �� Width$	 150�� �� CellTemplate# [  �� HeaderTemplate# [ �� $��Naziv��$	 300��# [ # [ �� $	��Kol��$ 50��# [ # [ �� $
��Cena��$	 100��# [ # [ �� -    ��Name$ btnNoviPopis��$��3��$��
Novi Popis��$��Right=�$��0,0,118.6,9.6q�$��75��$��19��$��Bottom=�$��
2147483642���� -   $ btnPrint��$��3��$��PRINT��$��Right=�$��0,0,24.6,9.6q�$��75��$��19��$��Bottom=�$��
2147483642���� -   $ btnBarkodIzvestaj��$��3��$��Barkod izvestaj��$��Right=�$��0,0,219.8,9.8q�$	��117��$��19��$��Bottom=�$��
2147483642��