﻿Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Dism
Imports System.Threading
Imports Microsoft.VisualBasic.ControlChars
Imports System.Text.Encoding
Imports DISMTools.Utilities

Public Class GetImgInfoDlg

    Dim ImageInfoCollection As DismImageInfoCollection
    Dim ImageInfoList As New List(Of DismImageInfo)
    Dim DismVersionChecker As FileVersionInfo

    Dim SelectedImageFile As String

    Private Sub GetImgInfoDlg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Text = "Get image information"
                        Label1.Text = Text
                        Label2.Text = "Image file to get information from:"
                        Label3.Text = "List of indexes of image file:"
                        Label22.Text = "Image version:"
                        Label24.Text = "Image name:"
                        Label26.Text = "Image description:"
                        Label31.Text = "Image size:"
                        Label41.Text = "Supports WIMBoot?"
                        Label43.Text = "Architecture:"
                        Label47.Text = "HAL:"
                        Label33.Text = "Service Pack build:"
                        Label28.Text = "Service Pack level:"
                        Label30.Text = "Installation type:"
                        Label39.Text = "Edition:"
                        Label45.Text = "Product type:"
                        Label5.Text = "Product suite:"
                        Label7.Text = "System root directory:"
                        Label9.Text = "File count:"
                        Label11.Text = "Dates:"
                        Label13.Text = "Installed languages:"
                        Label36.Text = "Image information"
                        Label37.Text = "Select an index on the list view on the left to view its information here"
                        RadioButton1.Text = "Currently mounted image"
                        RadioButton2.Text = "Another image"
                        Button1.Text = "Browse..."
                        Button2.Text = "Save..."
                        Button3.Text = "Pick..."
                        ListView1.Columns(0).Text = "Index"
                        ListView1.Columns(1).Text = "Image name"
                        OpenFileDialog1.Title = "Specify the image to get the information from"
                    Case "ESN"
                        Text = "Obtener información de la imagen"
                        Label1.Text = Text
                        Label2.Text = "Archivo de imagen del que obtener información:"
                        Label3.Text = "Listado de índices del archivo de imagen:"
                        Label22.Text = "Versión de la imagen:"
                        Label24.Text = "Nombre de la imagen:"
                        Label26.Text = "Descripción de la imagen:"
                        Label31.Text = "Tamaño de la imagen:"
                        Label41.Text = "¿Soporta WIMBoot?"
                        Label43.Text = "Arquitectura:"
                        Label47.Text = "HAL:"
                        Label33.Text = "Compilación de Service Pack:"
                        Label28.Text = "Nivel de Service Pack:"
                        Label30.Text = "Tipo de instalación:"
                        Label39.Text = "Edición:"
                        Label45.Text = "Tipo de producto:"
                        Label5.Text = "Suite de producto:"
                        Label7.Text = "Directorio raíz del sistema:"
                        Label9.Text = "Número de archivos:"
                        Label11.Text = "Fechas:"
                        Label13.Text = "Idiomas instalados:"
                        Label36.Text = "Información de la imagen"
                        Label37.Text = "Seleccione un índice del listado de la izquierda para ver su información aquí"
                        RadioButton1.Text = "Imagen montada actualmente"
                        RadioButton2.Text = "Otra imagen"
                        Button1.Text = "Examinar..."
                        Button2.Text = "Guardar..."
                        Button3.Text = "Escoger..."
                        ListView1.Columns(0).Text = "Índice"
                        ListView1.Columns(1).Text = "Nombre de imagen"
                        OpenFileDialog1.Title = "Especifique la imagen de la que obtener información"
                    Case "FRA"
                        Text = "Obtenir des informations de l'image"
                        Label1.Text = Text
                        Label2.Text = "Fichier image à partir duquel les informations sont obtenues :"
                        Label3.Text = "Liste des index du fichier d'image :"
                        Label22.Text = "Version de l'image :"
                        Label24.Text = "Nom de l'image :"
                        Label26.Text = "Description de l'image :"
                        Label31.Text = "Taille de l'image :"
                        Label41.Text = "Supporte WIMBoot ?"
                        Label43.Text = "Architecture :"
                        Label47.Text = "HAL :"
                        Label33.Text = "Compilation du Service Pack ::"
                        Label28.Text = "Niveau du Service Pack :"
                        Label30.Text = "Type d'installation :"
                        Label39.Text = "Édition:"
                        Label45.Text = "Type de produit :"
                        Label5.Text = "Suite de produit :"
                        Label7.Text = "Répertoire racine du système :"
                        Label9.Text = "Nombre de fichiers :"
                        Label11.Text = "Dates:"
                        Label13.Text = "Langues installées :"
                        Label36.Text = "Information de l'image"
                        Label37.Text = "Sélectionnez un index dans la liste de gauche pour afficher son information ici."
                        RadioButton1.Text = "Image actuellement montée"
                        RadioButton2.Text = "Autre image"
                        Button1.Text = "Parcourir..."
                        Button2.Text = "Sauvegarder..."
                        Button3.Text = "Choisir..."
                        ListView1.Columns(0).Text = "Index"
                        ListView1.Columns(1).Text = "Nom de l'image"
                        OpenFileDialog1.Title = "Spécifier l'image à partir de laquelle l'information doit être obtenue"
                    Case "PTB", "PTG"
                        Text = "Obter informações sobre a imagem"
                        Label1.Text = Text
                        Label2.Text = "Ficheiro de imagem de onde obter informações:"
                        Label3.Text = "Lista de índices do ficheiro de imagem:"
                        Label22.Text = "Versão da imagem:"
                        Label24.Text = "Nome da imagem:"
                        Label26.Text = "Descrição da imagem:"
                        Label31.Text = "Tamanho da imagem:"
                        Label41.Text = "Suporta WIMBoot?"
                        Label43.Text = "Arquitetura:"
                        Label47.Text = "HAL:"
                        Label33.Text = "Service Pack build:"
                        Label28.Text = "Nível do Service Pack:"
                        Label30.Text = "Tipo de instalação:"
                        Label39.Text = "Edição:"
                        Label45.Text = "Tipo de produto:"
                        Label5.Text = "Conjunto de produtos:"
                        Label7.Text = "Diretório raiz do sistema:"
                        Label9.Text = "Contagem de ficheiros:"
                        Label11.Text = "Datas:"
                        Label13.Text = "Idiomas instalados:"
                        Label36.Text = "Informações sobre a imagem"
                        Label37.Text = "Seleccione um índice na vista de lista à esquerda para ver a respectiva informação aqui"
                        RadioButton1.Text = "Imagem atualmente montada"
                        RadioButton2.Text = "Outra imagem"
                        Button1.Text = " Navegar..."
                        Button2.Text = "Guardar..."
                        Button3.Text = "Selecionar..."
                        ListView1.Columns(0).Text = "Índice"
                        ListView1.Columns(1).Text = "Nome da imagem"
                        OpenFileDialog1.Title = "Especificar a imagem da qual obter a informação"
                    Case "ITA"
                        Text = "Ottieni informazioni sull'immagine"
                        Label1.Text = Text
                        Label2.Text = "File immagine da cui ottenere informazioni:"
                        Label3.Text = "Elenco degli indici del file immagine:"
                        Label22.Text = "Versione immagine:"
                        Label24.Text = "Nome immagine:"
                        Label26.Text = "Descrizione immagine:"
                        Label31.Text = "Dimensione immagine:"
                        Label41.Text = "Supporta WIMBoot?"
                        Label43.Text = "Architettura:"
                        Label47.Text = "HAL:"
                        Label33.Text = "Service Pack build:"
                        Label28.Text = "Livello del Service Pack:"
                        Label30.Text = "Tipo di installazione:"
                        Label39.Text = "Edizione:"
                        Label45.Text = "Tipo di prodotto:"
                        Label5.Text = "Suite di prodotti:"
                        Label7.Text = "Directory principale del sistema:"
                        Label9.Text = "Numero di file:"
                        Label11.Text = "Date:"
                        Label13.Text = "Lingue installate:"
                        Label36.Text = "Informazioni sull'immagine"
                        Label37.Text = "Selezionare un indice nella vista elenco a sinistra per visualizzarne le informazioni qui"
                        RadioButton1.Text = "Immagine attualmente montata"
                        RadioButton2.Text = "Un'altra immagine"
                        Button1.Text = "Sfoglia..."
                        Button2.Text = "Salva..."
                        Button3.Text = "Scegli..."
                        ListView1.Columns(0).Text = "Indice"
                        ListView1.Columns(1).Text = "Nome dell'immagine"
                        OpenFileDialog1.Title = "Specificare l'immagine da cui ottenere le informazioni"
                End Select
            Case 1
                Text = "Get image information"
                Label1.Text = Text
                Label2.Text = "Image file to get information from:"
                Label3.Text = "List of indexes of image file:"
                Label22.Text = "Image version:"
                Label24.Text = "Image name:"
                Label26.Text = "Image description:"
                Label31.Text = "Image size:"
                Label41.Text = "Supports WIMBoot?"
                Label43.Text = "Architecture:"
                Label47.Text = "HAL:"
                Label33.Text = "Service Pack build:"
                Label28.Text = "Service Pack level:"
                Label30.Text = "Installation type:"
                Label39.Text = "Edition:"
                Label45.Text = "Product type:"
                Label5.Text = "Product suite:"
                Label7.Text = "System root directory:"
                Label9.Text = "File count:"
                Label11.Text = "Dates:"
                Label13.Text = "Installed languages:"
                Label36.Text = "Image information"
                Label37.Text = "Select an index on the list view on the left to view its information here"
                RadioButton1.Text = "Currently mounted image"
                RadioButton2.Text = "Another image"
                Button1.Text = "Browse..."
                Button2.Text = "Save..."
                Button3.Text = "Pick..."
                ListView1.Columns(0).Text = "Index"
                ListView1.Columns(1).Text = "Image name"
                OpenFileDialog1.Title = "Specify the image to get the information from"
            Case 2
                Text = "Obtener información de la imagen"
                Label1.Text = Text
                Label2.Text = "Archivo de imagen del que obtener información:"
                Label3.Text = "Listado de índices del archivo de imagen:"
                Label22.Text = "Versión de la imagen:"
                Label24.Text = "Nombre de la imagen:"
                Label26.Text = "Descripción de la imagen:"
                Label31.Text = "Tamaño de la imagen:"
                Label41.Text = "¿Soporta WIMBoot?"
                Label43.Text = "Arquitectura:"
                Label47.Text = "HAL:"
                Label33.Text = "Compilación de Service Pack:"
                Label28.Text = "Nivel de Service Pack:"
                Label30.Text = "Tipo de instalación:"
                Label39.Text = "Edición:"
                Label45.Text = "Tipo de producto:"
                Label5.Text = "Suite de producto:"
                Label7.Text = "Directorio raíz del sistema:"
                Label9.Text = "Número de archivos:"
                Label11.Text = "Fechas:"
                Label13.Text = "Idiomas instalados:"
                Label36.Text = "Información de la imagen"
                Label37.Text = "Seleccione un índice del listado de la izquierda para ver su información aquí"
                RadioButton1.Text = "Imagen montada actualmente"
                RadioButton2.Text = "Otra imagen"
                Button1.Text = "Examinar..."
                Button2.Text = "Guardar..."
                Button3.Text = "Escoger..."
                ListView1.Columns(0).Text = "Índice"
                ListView1.Columns(1).Text = "Nombre de imagen"
                OpenFileDialog1.Title = "Especifique la imagen de la que obtener información"
            Case 3
                Text = "Obtenir des informations de l'image"
                Label1.Text = Text
                Label2.Text = "Fichier image à partir duquel les informations sont obtenues :"
                Label3.Text = "Liste des index du fichier d'image :"
                Label22.Text = "Version de l'image :"
                Label24.Text = "Nom de l'image :"
                Label26.Text = "Description de l'image :"
                Label31.Text = "Taille de l'image :"
                Label41.Text = "Supporte WIMBoot ?"
                Label43.Text = "Architecture :"
                Label47.Text = "HAL :"
                Label33.Text = "Compilation du Service Pack ::"
                Label28.Text = "Niveau du Service Pack :"
                Label30.Text = "Type d'installation :"
                Label39.Text = "Édition:"
                Label45.Text = "Type de produit :"
                Label5.Text = "Suite de produit :"
                Label7.Text = "Répertoire racine du système :"
                Label9.Text = "Nombre de fichiers :"
                Label11.Text = "Dates:"
                Label13.Text = "Langues installées :"
                Label36.Text = "Information de l'image"
                Label37.Text = "Sélectionnez un index dans la liste de gauche pour afficher son information ici."
                RadioButton1.Text = "Image actuellement montée"
                RadioButton2.Text = "Autre image"
                Button1.Text = "Parcourir..."
                Button2.Text = "Sauvegarder..."
                Button3.Text = "Choisir..."
                ListView1.Columns(0).Text = "Index"
                ListView1.Columns(1).Text = "Nom de l'image"
                OpenFileDialog1.Title = "Spécifier l'image à partir de laquelle l'information doit être obtenue"
            Case 4
                Text = "Obter informações sobre a imagem"
                Label1.Text = Text
                Label2.Text = "Ficheiro de imagem de onde obter informações:"
                Label3.Text = "Lista de índices do ficheiro de imagem:"
                Label22.Text = "Versão da imagem:"
                Label24.Text = "Nome da imagem:"
                Label26.Text = "Descrição da imagem:"
                Label31.Text = "Tamanho da imagem:"
                Label41.Text = "Suporta WIMBoot?"
                Label43.Text = "Arquitetura:"
                Label47.Text = "HAL:"
                Label33.Text = "Service Pack build:"
                Label28.Text = "Nível do Service Pack:"
                Label30.Text = "Tipo de instalação:"
                Label39.Text = "Edição:"
                Label45.Text = "Tipo de produto:"
                Label5.Text = "Conjunto de produtos:"
                Label7.Text = "Diretório raiz do sistema:"
                Label9.Text = "Contagem de ficheiros:"
                Label11.Text = "Datas:"
                Label13.Text = "Idiomas instalados:"
                Label36.Text = "Informações sobre a imagem"
                Label37.Text = "Seleccione um índice na vista de lista à esquerda para ver a respectiva informação aqui"
                RadioButton1.Text = "Imagem atualmente montada"
                RadioButton2.Text = "Outra imagem"
                Button1.Text = " Navegar..."
                Button2.Text = "Guardar..."
                Button3.Text = "Selecionar..."
                ListView1.Columns(0).Text = "Índice"
                ListView1.Columns(1).Text = "Nome da imagem"
                OpenFileDialog1.Title = "Especificar a imagem da qual obter a informação"
            Case 5
                Text = "Ottieni informazioni sull'immagine"
                Label1.Text = Text
                Label2.Text = "File immagine da cui ottenere informazioni:"
                Label3.Text = "Elenco degli indici del file immagine:"
                Label22.Text = "Versione immagine:"
                Label24.Text = "Nome immagine:"
                Label26.Text = "Descrizione immagine:"
                Label31.Text = "Dimensione immagine:"
                Label41.Text = "Supporta WIMBoot?"
                Label43.Text = "Architettura:"
                Label47.Text = "HAL:"
                Label33.Text = "Service Pack build:"
                Label28.Text = "Livello del Service Pack:"
                Label30.Text = "Tipo di installazione:"
                Label39.Text = "Edizione:"
                Label45.Text = "Tipo di prodotto:"
                Label5.Text = "Suite di prodotti:"
                Label7.Text = "Directory principale del sistema:"
                Label9.Text = "Numero di file:"
                Label11.Text = "Date:"
                Label13.Text = "Lingue installate:"
                Label36.Text = "Informazioni sull'immagine"
                Label37.Text = "Selezionare un indice nella vista elenco a sinistra per visualizzarne le informazioni qui"
                RadioButton1.Text = "Immagine attualmente montata"
                RadioButton2.Text = "Un'altra immagine"
                Button1.Text = "Sfoglia..."
                Button2.Text = "Salva..."
                Button3.Text = "Scegli..."
                ListView1.Columns(0).Text = "Indice"
                ListView1.Columns(1).Text = "Nome dell'immagine"
                OpenFileDialog1.Title = "Specificare l'immagine da cui ottenere le informazioni"
        End Select
        If MainForm.BackColor = Color.FromArgb(48, 48, 48) Then
            Win10Title.BackColor = Color.FromArgb(48, 48, 48)
            BackColor = Color.FromArgb(31, 31, 31)
            ForeColor = Color.White
            TextBox1.BackColor = Color.FromArgb(31, 31, 31)
            ListView1.BackColor = Color.FromArgb(31, 31, 31)
            LanguageList.BackColor = Color.FromArgb(31, 31, 31)
        ElseIf MainForm.BackColor = Color.FromArgb(239, 239, 242) Then
            Win10Title.BackColor = Color.White
            BackColor = Color.FromArgb(238, 238, 242)
            ForeColor = Color.Black
            TextBox1.BackColor = Color.FromArgb(238, 238, 242)
            ListView1.BackColor = Color.FromArgb(238, 238, 242)
            LanguageList.BackColor = Color.FromArgb(238, 238, 242)
        End If
        TextBox1.ForeColor = ForeColor
        ListView1.ForeColor = ForeColor
        LanguageList.ForeColor = ForeColor
        Dim handle As IntPtr = MainForm.GetWindowHandle(Me)
        If MainForm.IsWindowsVersionOrGreater(10, 0, 18362) Then MainForm.EnableDarkTitleBar(handle, MainForm.BackColor = Color.FromArgb(48, 48, 48))
        DismVersionChecker = FileVersionInfo.GetVersionInfo(MainForm.DismExe)
        If Environment.OSVersion.Version.Major = 10 Then
            Text = ""
            Win10Title.Visible = True
        End If
        If Not MainForm.IsImageMounted Or MainForm.OnlineManagement Then
            RadioButton1.Enabled = False
            RadioButton1.Checked = False
            RadioButton2.Checked = True
            If TextBox1.Text <> "" And File.Exists(TextBox1.Text) Then Button2.Enabled = True Else Button2.Enabled = False
        Else
            RadioButton1.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        TextBox1.Text = OpenFileDialog1.FileName
    End Sub

    Sub GetImageInfo(ImageFile As String)
        If MainForm.MountedImageDetectorBW.IsBusy Then
            MainForm.MountedImageDetectorBW.CancelAsync()
            While MainForm.MountedImageDetectorBW.IsBusy
                Application.DoEvents()
                Thread.Sleep(500)
            End While
        End If
        MainForm.WatcherTimer.Enabled = False
        If MainForm.WatcherBW.IsBusy Then MainForm.WatcherBW.CancelAsync()
        While MainForm.WatcherBW.IsBusy
            Application.DoEvents()
            Thread.Sleep(100)
        End While
        ImageInfoList.Clear()
        ListView1.Items.Clear()
        Try
            SelectedImageFile = ImageFile
            DismApi.Initialize(DismLogLevel.LogErrors)
            ImageInfoCollection = DismApi.GetImageInfo(ImageFile)
            For Each ImageInfo As DismImageInfo In ImageInfoCollection
                ImageInfoList.Add(ImageInfo)
                ListView1.Items.Add(New ListViewItem(New String() {ImageInfo.ImageIndex, ImageInfo.ImageName}))
            Next
        Catch ex As Exception
            Dim msg As String = ""
            Select Case MainForm.Language
                Case 0
                    Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                        Case "ENU", "ENG"
                            msg = "Could not gather information of this image file. Reason:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                        Case "ESN"
                            msg = "No pudimos obtener información de este archivo de imagen. Razón:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                        Case "FRA"
                            msg = "Impossible de recueillir des informations sur ce fichier de l'image. Raison :" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                        Case "PTB", "PTG"
                            msg = "Não foi possível recolher informações sobre este ficheiro de imagem. Motivo:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                        Case "ITA"
                            msg = "Impossibile raccogliere informazioni sull'immagine. Motivo:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                    End Select
                Case 1
                    msg = "Could not gather information of this image file. Reason:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                Case 2
                    msg = "No pudimos obtener información de este archivo de imagen. Razón:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                Case 3
                    msg = "Impossible de recueillir des informations sur ce fichier de l'image. Raison :" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                Case 4
                    msg = "Não foi possível recolher informações sobre este ficheiro de imagem. Motivo:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
                Case 5
                    msg = "Impossibile raccogliere informazioni sull'immagine. Motivo:" & CrLf & CrLf & ex.ToString() & " - " & ex.Message & " (HRESULT " & Hex(ex.HResult) & ")"
            End Select
            MsgBox(msg, vbOKOnly + vbCritical, Label1.Text)
        Finally
            Try
                DismApi.Shutdown()
            Catch ex As Exception
                ' Don't do anything
            End Try
        End Try
    End Sub

    Sub DisplayImageInfo(Index As Integer)
        Label23.Text = ImageInfoList(Index).ProductVersion.ToString()
        DetectFeatureUpdate(ImageInfoList(Index).ProductVersion)
        Label25.Text = ImageInfoList(Index).ImageName
        Label35.Text = ImageInfoList(Index).ImageDescription
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
                    Case "ESN"
                        Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
                    Case "FRA"
                        Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " octets (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize, True) & ")"
                    Case "PTB", "PTG"
                        Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
                    Case "ITA"
                        Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
                End Select
            Case 1
                Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
            Case 2
                Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
            Case 3
                Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " octets (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize, True) & ")"
            Case 4
                Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
            Case 5
                Label32.Text = ImageInfoList(Index).ImageSize.ToString("N0") & " bytes (~" & Converters.BytesToReadableSize(ImageInfoList(Index).ImageSize) & ")"
        End Select

        Label42.Text = Casters.CastDismArchitecture(ImageInfoList(Index).Architecture, True)
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Undefined by the image")
                    Case "ESN"
                        Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "No definida por la imagen")
                    Case "FRA"
                        Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Non défini par l'image")
                    Case "PTB", "PTG"
                        Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Não definido pela imagem")
                    Case "ITA"
                        Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Non definito dall'immagine")
                End Select
            Case 1
                Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Undefined by the image")
            Case 2
                Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "No definida por la imagen")
            Case 3
                Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Non défini par l'image")
            Case 4
                Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Não definido pela imagem")
            Case 5
                Label46.Text = If(Not ImageInfoList(Index).Hal = "", ImageInfoList(Index).Hal, "Non definito dall'immagine")
        End Select
        Label34.Text = ImageInfoList(Index).ProductVersion.Revision
        Label27.Text = ImageInfoList(Index).SpLevel
        Label29.Text = ImageInfoList(Index).InstallationType
        Label38.Text = ImageInfoList(Index).EditionId
        Label4.Text = ImageInfoList(Index).ProductType
        Label44.Text = ImageInfoList(Index).ProductSuite
        Label8.Text = ImageInfoList(Index).SystemRoot
        LanguageList.Items.Clear()
        For Each language In ImageInfoList(Index).Languages
            Select Case MainForm.Language
                Case 0
                    Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                        Case "ENU", "ENG"
                            LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", default", "") & ")")
                        Case "ESN"
                            LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", predeterminado", "") & ")")
                        Case "FRA"
                            LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", défaut", "") & ")")
                        Case "PTB", "PTG"
                            LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", predefinido", "") & ")")
                        Case "ITA"
                            LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", predefinito", "") & ")")
                    End Select
                Case 1
                    LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", default", "") & ")")
                Case 2
                    LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", predeterminado", "") & ")")
                Case 3
                    LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", défaut", "") & ")")
                Case 4
                    LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", predefinido", "") & ")")
                Case 5
                    LanguageList.Items.Add(language.Name & " (" & language.DisplayName & If(ImageInfoList(Index).DefaultLanguage.Name = language.Name, ", predefinito", "") & ")")
            End Select
        Next
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " files in " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " directories"
                        Label10.Text = "Date created: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                            "Date modified: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
                    Case "ESN"
                        Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " archivos en " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " directorios"
                        Label10.Text = "Fecha de creación: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                            "Fecha de modificación: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
                    Case "FRA"
                        Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " fichiers dans " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " répertoires"
                        Label10.Text = "Date de création : " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                            "Date de modification : " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
                    Case "PTB", "PTG"
                        Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " ficheiros em " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " directórios"
                        Label10.Text = "Data de criação: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                            "Data de modificação: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
                    Case "ITA"
                        Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " file in " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " cartelle"
                        Label10.Text = "Data di creazione: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                            "Data di modifica: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
                End Select
            Case 1
                Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " files in " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " directories"
                Label10.Text = "Date created: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                    "Date modified: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
            Case 2
                Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " archivos en " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " directorios"
                Label10.Text = "Fecha de creación: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                    "Fecha de modificación: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
            Case 3
                Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " fichiers dans " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " répertoires"
                Label10.Text = "Date de création : " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                    "Date de modification : " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
            Case 4
                Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " ficheiros em " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " directórios"
                Label10.Text = "Data de criação: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                    "Data de modificação: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
            Case 5
                Label6.Text = ImageInfoList(Index).CustomizedInfo.FileCount & " file in " & ImageInfoList(Index).CustomizedInfo.DirectoryCount & " cartelle"
                Label10.Text = "Data di creazione: " & ImageInfoList(Index).CustomizedInfo.CreatedTime & CrLf & _
                    "Data di modifica: " & ImageInfoList(Index).CustomizedInfo.ModifiedTime
        End Select

        ' The DISM API part is over. Switch to regular DISM.exe mode for missing details
        Try     ' Try getting image properties
            If Not Directory.Exists(Application.StartupPath & "\tempinfo") Then
                Directory.CreateDirectory(Application.StartupPath & "\tempinfo").Attributes = FileAttributes.Hidden
            End If
            Select Case DismVersionChecker.ProductMajorPart
                Case 6
                    Select Case DismVersionChecker.ProductMinorPart
                        Case 1
                            File.WriteAllText(Application.StartupPath & "\bin\exthelpers\imginfo.bat",
                                              "@echo off" & CrLf &
                                              "dism /English /get-wiminfo /wimfile=" & Quote & SelectedImageFile & Quote & " /index=" & ListView1.FocusedItem.Index + 1 & " | findstr /c:" & Quote & "WIM Bootable" & Quote & " /b > " & Quote & Application.StartupPath & "\tempinfo\imgwimboot" & Quote, ASCII)
                        Case Is >= 2
                            File.WriteAllText(Application.StartupPath & "\bin\exthelpers\imginfo.bat",
                                              "@echo off" & CrLf &
                                              "dism /English /get-imageinfo /imagefile=" & Quote & SelectedImageFile & Quote & " /index=" & ListView1.FocusedItem.Index + 1 & " | findstr /c:" & Quote & "WIM Bootable" & Quote & " /b > " & Quote & Application.StartupPath & "\tempinfo\imgwimboot" & Quote, ASCII)
                    End Select
                Case 10
                    File.WriteAllText(Application.StartupPath & "\bin\exthelpers\imginfo.bat",
                                      "@echo off" & CrLf &
                                      "dism /English /get-imageinfo /imagefile=" & Quote & SelectedImageFile & Quote & " /index=" & ListView1.FocusedItem.Index + 1 & " | findstr /c:" & Quote & "WIM Bootable" & Quote & " /b > " & Quote & Application.StartupPath & "\tempinfo\imgwimboot" & Quote, ASCII)
            End Select
            If Debugger.IsAttached Then
                Process.Start("\Windows\system32\notepad.exe", Application.StartupPath & "\bin\exthelpers\imginfo.bat").WaitForExit()
            End If
            Using WIMBootProc As New Process()
                WIMBootProc.StartInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.Windows) & "\system32\cmd.exe"
                WIMBootProc.StartInfo.Arguments = "/c " & Quote & Application.StartupPath & "\bin\exthelpers\imginfo.bat" & Quote
                WIMBootProc.StartInfo.CreateNoWindow = True
                WIMBootProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                WIMBootProc.Start()
                WIMBootProc.WaitForExit()
            End Using
            Try
                Label40.Text = My.Computer.FileSystem.ReadAllText(Application.StartupPath & "\tempinfo\imgwimboot", ASCII).Replace("WIM Bootable : ", "").Trim()
                If Not MainForm.ImgBW.IsBusy Then
                    For Each foundFile In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\tempinfo", FileIO.SearchOption.SearchTopLevelOnly)
                        File.Delete(foundFile)
                    Next
                    Directory.Delete(Application.StartupPath & "\tempinfo")
                End If
                File.Delete(Application.StartupPath & "\bin\exthelpers\imginfo.bat")
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Sub DetectFeatureUpdate(SysVer As Version)
        Dim FeatUpd As String = ""
        Select Case SysVer.Major
            Case 10
                Select Case SysVer.Build
                    Case 9650 To 10240
                        FeatUpd = "1507 (Threshold 1)"
                    Case 10525 To 10587     ' 10587 is a Post-RTM build of Windows 10 November Update
                        FeatUpd = "1511 (Threshold 2)"
                    Case 11065 To 14393
                        FeatUpd = "1607 (Redstone 1)"
                    Case 14832 To 15063
                        FeatUpd = "1703 (Redstone 2)"
                    Case 15140 To 16299
                        FeatUpd = "1709 (Redstone 3)"
                    Case 16251 To 17134
                        FeatUpd = "1803 (Redstone 4)"
                    Case 17604 To 17763
                        FeatUpd = "1809 (Redstone 5)"
                    Case 18204 To 18362
                        FeatUpd = "1903 (Titanium)"
                    Case Is = 18362
                        If SysVer.Revision >= 10000 Then
                            FeatUpd = "1909 (Vanadium)"
                        Else
                            FeatUpd = "1903 (Titanium)"
                        End If
                    Case Is = 18363
                        FeatUpd = "1909 (Vanadium)"
                    Case 18826 To 19041
                        FeatUpd = "2004 (Vibranium)"
                    Case 19041 To 19489
                        FeatUpd = "2004+ (Vibranium)"
                    Case 19489 To 19645
                        FeatUpd = "2004 (Manganese)"
                    Case 20124 To 20279
                        FeatUpd = "21H1 (Iron)"
                    Case 20282 To 20348
                        FeatUpd = "21H2 (Iron)"
                    Case 21242 To 22000     ' Also includes Windows 11 Cobalt (21H2)
                        FeatUpd = "21H2 (Cobalt)"
                    Case 22350 To 22630     ' This goes until Windows 11 build 22631 (2022 Update Moment 4)
                        FeatUpd = "22H2 (Nickel)"
                    Case 22631 To 22634
                        FeatUpd = "23H2 (Nickel)"
                    Case 22635 To 23400
                        FeatUpd = "23H2 (Nickel Moment 5)"
                    Case 23401 To 25000
                        FeatUpd = "Dev (Nickel)"
                    Case 25057 To 25238
                        FeatUpd = "23H1 (Copper)"
                    Case 25240 To 25400     ' 25400 is a relative number. 25398 is the final build of Zinc
                        FeatUpd = "23H2 (Zinc)"
                    Case 25801 To 25941
                        FeatUpd = "24H1 (Gallium)"
                    Case 25942 To 27500
                        FeatUpd = "24H2 (Germanium)"
                    Case 27501 To 27686
                        FeatUpd = "25H1 (Dilithium)"
                    Case Is >= 27687
                        FeatUpd = "25H2 (Selenium)"
                End Select
            Case Else
                Exit Sub
        End Select
        Select Case MainForm.Language
            Case 0
                Select Case My.Computer.Info.InstalledUICulture.ThreeLetterWindowsLanguageName
                    Case "ENU", "ENG"
                        Label23.Text &= " (feature update: " & FeatUpd & ")"
                    Case "ESN"
                        Label23.Text &= " (actualización de características: " & FeatUpd & ")"
                    Case "FRA"
                        Label23.Text &= "(m-à-j des caractéristiques: " & FeatUpd & ")"
                    Case "PTB", "PTG"
                        Label23.Text &= " (atualização de funcionalidades: " & FeatUpd & ")"
                    Case "ITA"
                        Label23.Text &= " (aggiornamento della caratteristica: " & FeatUpd & ")"
                End Select
            Case 1
                Label23.Text &= " (feature update: " & FeatUpd & ")"
            Case 2
                Label23.Text &= " (actualización de características: " & FeatUpd & ")"
            Case 3
                Label23.Text &= "(m-à-j des caractéristiques: " & FeatUpd & ")"
            Case 4
                Label23.Text &= " (atualização de funcionalidades: " & FeatUpd & ")"
            Case 5
                Label23.Text &= " (aggiornamento della caratteristica: " & FeatUpd & ")"
        End Select
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" And File.Exists(TextBox1.Text) Then
            GetImageInfo(TextBox1.Text)
            Button2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Button2.Enabled = False
        If RadioButton1.Checked Then
            ' Go through the mounted image listings to find the appropriate image
            If MainForm.MountedImageImgFiles.Count > 0 Then
                TextBox1.Enabled = False
                Button1.Enabled = False
                Button3.Enabled = False
                For x = 0 To Array.LastIndexOf(MainForm.MountedImageImgFiles, MainForm.MountedImageImgFiles.Last)
                    If MainForm.MountedImageMountDirs(x) = MainForm.MountDir Then
                        GetImageInfo(MainForm.MountedImageImgFiles(x))
                        Button2.Enabled = True
                        Exit For
                    End If
                Next
            End If
        Else
            TextBox1.Enabled = True
            Button1.Enabled = True
            Button3.Enabled = True

            ' If the user had specified an image file, get information of it immediately
            If TextBox1.Text <> "" And File.Exists(TextBox1.Text) Then
                GetImageInfo(TextBox1.Text)
                Button2.Enabled = True
            End If
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        Try
            If ListView1.SelectedItems.Count = 1 Then
                Panel7.Visible = False
                Panel4.Visible = True
                DisplayImageInfo(ListView1.FocusedItem.Index)
            Else
                Panel7.Visible = True
                Panel4.Visible = False
            End If
        Catch ex As Exception
            Panel7.Visible = True
            Panel4.Visible = False
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub GetImgInfoDlg_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not MainForm.MountedImageDetectorBW.IsBusy And Not PleaseWaitDialog.Visible Then Call MainForm.MountedImageDetectorBW.RunWorkerAsync()
        MainForm.WatcherTimer.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MainForm.ImgInfoSFD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not ImgInfoSaveDlg.IsDisposed Then ImgInfoSaveDlg.Dispose()
            ImgInfoSaveDlg.SourceImage = SelectedImageFile
            ImgInfoSaveDlg.SaveTarget = MainForm.ImgInfoSFD.FileName
            ImgInfoSaveDlg.OnlineMode = False
            ImgInfoSaveDlg.OfflineMode = False
            ImgInfoSaveDlg.SaveTask = 1
            ImgInfoSaveDlg.ShowDialog()
            InfoSaveResults.Show()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PopupImageManager.Location = Button3.PointToScreen(Point.Empty)
        If PopupImageManager.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = PopupImageManager.selectedImgFile
        End If
    End Sub
End Class
