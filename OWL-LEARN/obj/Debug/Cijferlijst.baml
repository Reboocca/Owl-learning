   M S B A M L   `   `   `  ����  	OWL-LEARN    OWL_LEARN.Cijferlijst   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Cijferlijst��5   	   $	��520��6   $
��1200��6*   $
��1205��67   $	��600��6G   $
��1200��6W   $	��700��6g    � Icon$ Images/owl_cropped.png��6w    � 
ResizeMode$ NoResize=�6�   ��5      �� 5   
    �� ImageSource$5 /pack://siteoforigin:,,,/Images/awaken_large.png��6   .��5	      � $��0,0,-5,0q�6   ��6   Z� .+�5
   
   � $��Right=�6   $	��570��6+   $	��Top=�68   $	��280��6P   ���	#CCFFFFFF$��
0,-2,923,0q�6s    � ColumnDefinitions 5      �� 5      $��7* �6#   �� 5      $	��43* �6#   �� 5      $��7* �6#   .+�5      �� -   5         ��Name$ btTerug��5      $��Terug��6&   $
��Left=�66   $��2q�6Q   $��	0,518,0,0q�6]   $	��282��6p   $��18.667(�6|   ���	#FFEADEC5$��3��6�   $��46��6�   $	��Top=�6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � ��	 �� Value	 �#D3815B67   �� 5       � ��	 5      �� 5   "   
 �� 
TargetType"
 ��62   .R�5   &   �� #��z��6-   ._�5   *   �� $��Center=�6;   $��Center=�6X   5   '   5   #   5       �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5   "   ��  � ��	 �#e0a68c6?   5       5"      5$      �� 5%      $��1��6   $
��Left=�6$   $	��200��6?   $��5,48,0,0q�6L   $	��Top=�6^   $	��202��6v   $��Images/owl_cropped1.png��6�   $��UniformToFill=�6�    J� OpacityMask 5&      �� 5'      $ Images/owl_cropped.png��6!   5)      �� 5*      -   5         ��Name$ lbUser��5*      $	��...��6$   $��10q�62   $��Center=�6?   $��5,11,0,0q�6c   $	��Top=�6u   $��57��6�   $��Century Gothic)�6�   $��16(�6�   ���	#FF1F97AD$
��Left=�6�   $	��204��6�    J� RenderTransformOrigin$ -0.753,-1.167&�6  $��1��6'  � 5+      $��38��6   $��19,10,196,0q�6   $	��Top=�64   $ 0.372,0.729&�6L   $��2��6p   ��5,      �� 5-      $ Images/leerlingIcon.png��6!    j� Stretch$ Uniform=�6G   5/      50      � 51   
   $
��Left=�6   $	��446��6*   $��
306,86,0,0q�67   $	��Top=�6K   $	��850��6c   ���	#CCFFFFFF.+�52      �� $��Cijferlijst��6   $��Center=�6*   $	��Top=�6N   $��45��6f   $��Century Gothic)�6r   $��29.333(�6�   ���	#FFFF7556$��
10,10,10,0q�6�   &   System.Windows.Controls.DataGrid  53      -   5          Name$ 	dgCijfers��53         GridLinesVisibility$
 None=�6N   $
��Left=�6i   $��	50,60,0,0q�6�   $	��Top=�6�   $	��345��6�   $	��760��6�      
IsReadOnly . $��Century Gothic)�6�   ���	#FF1D1B1A
�������$��16(�67     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ SizeToCells 6E     MinColumnWidth$	 175Q�6_     CanUserResizeColumns .     CanUserResizeRows .  ��6*   �� *CijferTabel+��6�   Z�  � 	Resources 54      =  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�   '        �� 55      "  6   .�56      ��  � ��	 �	#FF1890BD67   �� 57       � ��
	 �����67   �� 58       � ��$	 5q�64   �� 59       � ��$	 20(�65   5:      5;      5<      5=      5?      5@      