   M S B A M L   `   `   `  ����  	OWL-LEARN    OWL_LEARN.lesWijzigen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Les wijzigen��5   	   $	��520��6   $
��1200��6+   $
��1205��68   $	��600��6H   $
��1200��6X   $	��700��6h    � Icon$ Images/owl_cropped.png��6x    � 
ResizeMode$ NoResize=�6�   ��5      �� 5   
    �� ImageSource$ Images/bluetree.png��6    j� Stretch$ UniformToFill=�67   .��5	      � $��0,0,-5,0q�6   ��5
   
   �� 5       � ColumnDefinitions 5   
   �� 5      $��1101* �6   �� 5      $
��103* �6   .+�5   
   � $��Right=�6   $	��570��6+   $	��Top=�68   $	��280��6P   ���	#CCFFFFFF$��
0,-2,820,0q�6s    5      �� 5      $��7* �6#   �� 5      $	��43* �6#   �� 5      $��7* �6#   .+�5      �� -   5         ��Name$ btTerug��5      $��Terug��6&   $
��Left=�66   $��2q�6Q   $��
0,518,-2,6q�6]   $	��282��6q   $��18.667(�6}   
�������$��3��6�   ��5      �� 5       �� 
TargetType" ��6   .�5      �� 	 �� Property	 � ��
 �� Value
 �#2783AA67   �� 5      	 � ��
 5      �� 5   "    �� 
TargetType" ��62   .R�5   &   �� #��z��6-   ._�5    *   �� $��Center=�6;   $��Center=�6X   5!   '   5"   #   5$       �� Triggers 5%      P� 5&       P� Property �@J�IsMouseOver P� Value . . �5'   "   �� 	 � ��
 �#529BBB6?   5(      5*      5,      �� 5-      $��1��6   $
��Left=�6$   $	��200��6?   $��9.005,36.866,0,0q�6L   $	��Top=�6f   $	��202��6~   $��Images/owl_cropped1.png��6�   $��UniformToFill=�6�    J� OpacityMask 5.      �� 5/      $ Images/owl_cropped.png��6!   51      52      � 53   
   $
��Left=�6   $	��366��6*   $��
308,96,0,0q�67   $	��Top=�6K   $	��288��6c   ���	#E5FFFFFF.+�54      �� -   5         ��Name$ lbVak��54      $��Wijzig naam of uitleg��6#   $
��Left=�6C   $	��Top=�6^   $��48��6v   $	��288��6�   $��Century Gothic)�6�   $��26.667(�6�   
����������	#FF913C3C6�   �� 55      -   5        $ btWijzigNaam��55      $��Opslaan��6+   $
��Left=�6=   $��2q�6X   $��	0,320,0,0q�6d   $	��288��6w   $��18.667(�6�   
�������$��46��6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.442,1.435&�6�   ��56      �� 57      " ��6   .�58      �� 	 � ��
 �#2783AA67   �� 59      	 � ��
 5:      �� 5;   "   " ��62   .R�5<   &   �� #��z��6-   ._�5=   *   �� $��Center=�6;   $��Center=�6X   5>   '   5?   #   5A       5B      P� 5C       �@J�IsMouseOver . . �5D   "   �� 	 � ��
 �#529BBB6?   5E      5G      5I      �� 5J      -   5         ��Name$ tbNaam��5J      $
��Left=�6&   $��5q�6A   $��34��6M   $��
10,126,0,0q�6Y    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��268��6�    �� TextAlignment$ Center=�6�   $��16(�6�   ���	#FF463428 �� SelectionBrush �	#FF5484366�   �� 5K      -   5        $ lbContent_Copy��5K      $\��VVul hieronde de nieuwe naam en 
uitleg in en klik op "opslaan" om 
deze op te slaan.��6,   $��	10,53,0,0q�6�   $	��Top=�6�   $��59��6�   $	��268��6�   $��Century Gothic)�6�   $��14(�6  ���	#FF8B6C51$
��Left=�6+  �� 5L      -   5         ��Name$ rbUitleg��5L      $
��Left=�6,   $��5q�6G   $	��141��6S   $��
10,165,0,0q�6`   $	��Top=�6t   $	��268��6�   $��16(�6�   ���	#FF463428 �	#FF548436. �5M      /� 5N      5P      � 5Q   
   $
��Left=�6   $	��366��6*   $��
631,96,0,0q�67   $	��Top=�6K   $	��537��6c   ���	#E5FFFFFF$��2��6�    5R      �� 5S      $
��121* �6#   �� 5T      $
��316* �6#   �� 5U      $
��121* �6#   .+�5W      �� -   5        $ 	lbContent��5W      $$��Vragen die in de les voorkomen��6'   $��-0.25,-0.25,0,0q�6P   $	��Top=�6i   $��48��6�   $	��537��6�   $��Century Gothic)�6�   $��26.667(�6�   
�������$
��Left=�6�   $��3��6�   ���	#FF913C3C6	  5X      �� 5Y   
   -   5         ��Name$ lbLijst��5Y      $
��Left=�6#   $	��204��6>   $��649,168,0,0q�6K   $	��Top=�6`   $	��502��6x   $��16(�6�   $��Century Gothic)�6�   ���	#CCF0FFF8���	#FF553A3A$��2��6�   ��5Z      �� 5[      .R�5\      �� ��6    �� *vraag+5]      5_      �� 5`   
   -	   5        $ btVerwijder��5`      $��Verwijderen��6&   $
��Left=�6<   $��2q�6W   $��649,409,0,0q�6c   $	��250��6x   $��18.667(�6�   
�������$��46��6�   $	��Top=�6�   $ 0.442,1.435&�6�   ��5a      �� 5b      " ��6   .�5c      �� 	 � ��
 �#2783AA63   �� 5d      	 � ��
 5e      �� 5f      " ��6.   .R�5g   "   �� #��z��6)   ._�5h   &   �� $��Center=�67   $��Center=�6T   5i   #   5j      5l       5m      P� 5n       �@J�IsMouseOver . . �5o      �� 	 � ��
 �#529BBB6;   5p      5r      5t      �� 5u   
   -
   5        $ 	btVoegToe��5u      $��	Toevoegen��6$   $
��Left=�68   $��2q�6S   $��906,409,0,0q�6_   $	��245��6t   $��18.667(�6�   
�������$��46��6�   $	��Top=�6�   $ 0.442,1.435&�6�   $��2��6�   ��5v      �� 5w      " ��6   .�5x      �� 	 � ��
 �#2783AA63   �� 5y      	 � ��
 5z      �� 5{      " ��6.   .R�5|   "   �� #��z��6)   ._�5}   &   �� $��Center=�67   $��Center=�6T   5~   #   5      5�       5�      P� 5�       �@J�IsMouseOver . . �5�      �� 	 � ��
 �#529BBB6;   5�      5�      5�      5�      5�      