   M S B A M L   `   `   `  ����K  GDatabaseExamples, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DatabaseExamplesDatabaseExamples  5   	   !    DatabaseExamples.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:DatabaseExamples     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   �� $��EmpNo��6   $
��Left=�6    $��	35,23,0,0q�6;   $	��Top=�6N   �� 5   
   -   5         ��Name$ txtEmpNo��5      $
��Left=�6$   $��23��6?   $��
102,23,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��	35,59,0,0q�6:   $	��Top=�6M   �� 5   
   -   5        $ txtName��5      $
��Left=�6#   $��23��6>   $��
102,59,0,0q�6J   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   $��Basic��6   $
��Left=�6    $��
35,102,0,0q�6;   $	��Top=�6O   �� 5   
   -   5        $ txtBasic��5      $
��Left=�6$   $��23��6?   $��102,102,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   $��DeptNo��6   $
��Left=�6!   $��
35,147,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ 	txtDeptNo��5      $
��Left=�6%   $��23��6@   $��102,147,0,0q�6L   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��120��6�   �� 5   
   -   5         ��Name$ 	btnInsert��5      $��Insert��6$   $
��Left=�65   $��
77,205,0,0q�6P   $	��Top=�6d   $��75��6|   6�   �� 5   
   -   5        $��Insert with Parameters��5      $
��Left=�62   $��187,205,0,0q�6M   $	��Top=�6b   $	��185��6z   6�   �� 5   
   -   5        $"��Insert with Stored Procedure��5      $
��Left=�68   $��
85,246,0,0q�6S   $	��Top=�6g   $	��277��6   6�   �� 5   
   -   5        $��Transaction��5      $
��Left=�6'   $��
85,288,0,0q�6B   $	��Top=�6V   $	��277��6n   6z   �� 5   
   -	   5        $��ExecuteScalar��5      $
��Left=�6)   $��
86,335,0,0q�6D   $	��Top=�6X   $	��276��6p   6|   5      5      