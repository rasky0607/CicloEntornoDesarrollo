   M S B A M L   `   `   `  ����G  CCatalogo2018, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Catalogo2018Catalogo2018  5   	       Catalogo2018.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ,localclr-namespace:Catalogo2018     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ Catálogo de Dvd��5   	   $��369.737��6!   $��759.211��62   .��5      �  � DataContext 5   
     Catalogo2018.CatalogoVM  5	      .+�5   
   &   System.Windows.Controls.DataGrid  $
��Left=�6   $��	10,23,0,0q�6.   $	��Top=�6A   $	��206��6Y   $	��723��6f      CanUserAddRows .  ��6r   �� *	Listado+ �� SelectedItem 6�   �� *DvdSeleccionado+6�   �� 5   
   -   5         ��Name$ btnconectar��5      $��Conectar��6&   $
��Left=�69   $��
10,229,0,0q�6T   $	��Top=�6h   $��75��6�   ��6�   �� *ColorConectar+��6�   �� *ConectarBD_click+ �� Mode$ OneWay=��� 5   
   -   5        $ btndesconectar��5      $��Desconectar��6)   $
��Left=�6?   $��658,229,0,0q�6Z   $	��Top=�6o   $��75��6�   {�6�   �� *	Conectado+$ OneWay=���6�   �� *DesconectarBD_click+$ OneWay=��� 5   
   -   5        $ 	btnlistar��5      $��Listar DVDs��6$   $
��Left=�6:   $��148,229,0,0q�6U   $	��Top=�6j   $��75��6�   {�6�   �� *	Conectado+$ OneWay=���6�   �� *ListarTodosDVD_Click+$ OneWay=��� 5   
   -   5         ��Name$ lbestado��5      $
��Left=�6>   $��
10,297,0,0q�6Y   $	��Top=�6m   $	��666��6�   ��6"   �� *	Mensaje+6�   	� 5   
   -   5         	�Name$ rbsql��5      $	��SQL��6%   $
��Left=�63   $��331,229,0,0q�6N   $	��Top=�6c   	 	� 	GroupName$	 bd��6{   
 d� 	IsChecked
 6�   �� *TipoConexion+	� 5   
   -   5        $ rbsqlite��5      $��SqLite��6(   $
��Left=�69   $��474,229,0,0q�6T   $	��Top=�6i   $	 bd��6�   �� 5   
   -   5        $��	btnBorrar��5      $��Borrar��6"   $
��Left=�63   $��
10,251,0,0q�6N   $	��Top=�6b   $��75��6z   ��6�   �� *BorrarDVDBD_click+$ OneWay=�{�6�   �� *	Conectado+$ OneWay=��� 5   
   -   5        $��btnActualizar��5      $��
Actualizar��6&   $
��Left=�6;   $��148,256,0,0q�6V   $	��Top=�6k   $��75��6�    J� RenderTransformOrigin$ 	0.4,0.591&�6�   {�6�   �� *	Conectado+$ OneWay=�5      5      