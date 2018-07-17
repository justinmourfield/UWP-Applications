<Page
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:Vigilance"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:Maps="using:Windows.UI.Xaml.Controls.Maps"
    x:Class="Vigilance.MainPage"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Grid >
        <Maps:MapControl x:Name="myMap" HorizontalAlignment="Left" VerticalAlignment="Center" Layers="{x:Bind ViewModel.LayerCollection}" RotateInteractionMode="Auto"  MapServiceToken="cTr7mik853Nm31dEUZ4s~IzwGC2_ijRPgmC0IhyMcNA~Avhs5mUXBJtB7cnPm6FmPKVjaHqG7Pd7gesPUsxTQcCT9QLo7SRan4yGbUyxRETB" Margin="350,0,0,0" Height="713" Width="930" MapElementClick="myMap_MapElementClick_1" />
        <StackPanel x:Name="FilterBox" HorizontalAlignment="Left" Height="717" VerticalAlignment="Top" Width="229" BorderBrush="MediumVioletRed" BorderThickness="2">
            <TextBlock x:Name="FilterBar_Title_" Text="Refine Search" HorizontalAlignment="Center" VerticalAlignment="Center" Margin="0,10,0,10"/>
            <CheckBox x:Name="Arson"  Content="Arson" HorizontalAlignment="Left" Margin="0,0,0,0" VerticalAlignment="Top" />
            <CheckBox x:Name="Assault" Content="Assault"/>
            <CheckBox x:Name="Burglary" Content="Burglary"/>
            <CheckBox x:Name="CriminalTraffic" Content="Criminal Traffic"/>
            <CheckBox x:Name="DrugPossession" Content="Drug Possession"/>
            <CheckBox x:Name="DrugSaleAndManufacture" Content="Drug Sale/Manufacture"/>
            <CheckBox x:Name="FraudOrForgery" Content="Fraud or Forgery"/>
            <CheckBox x:Name="Homicide" Content="Homicide"/>
            <CheckBox x:Name="Intimidation" Content="Intimidation"/>
            <CheckBox x:Name="LiquorLawViolation" Content="Liquor Law Violation"/>
            <CheckBox x:Name="MotorVehicleTheft" Content="Motor Vehicle Theft"/>
            <CheckBox x:Name="PossesionOfStolenProperty" Content="Possession of Stolen Property"/>
            <CheckBox x:Name="Robbery" Content="Robbery"/>
            <CheckBox x:Name="TelephoneHarrassment" Content="Telephone Harassment"/>
            <CheckBox x:Name="Theft" Content="Theft"/>
            <CheckBox x:Name="TraffickingStolenProperty" Content="Trafficking in Stolen Property"/>
            <CheckBox x:Name="Vandalism" Content="Vandalism"/>
            <CheckBox x:Name="WarrantArrests" Content="Warrant Arrests" HorizontalAlignment="Left" Margin="0,0,0,10" VerticalAlignment="Top"/>
            <Button Content="Update Search" HorizontalAlignment="Center" VerticalAlignment="Center" Margin="0,0,0,15" Click="Update_Button_Click"/>
            <Button Content="Reset Search" HorizontalAlignment="Center" VerticalAlignment="Center" Width="118"/>
        </StackPanel>

    </Grid>
</Page>
