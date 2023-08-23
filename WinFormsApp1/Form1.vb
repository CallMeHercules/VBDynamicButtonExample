Imports System.Data

Public Class Form1
    Inherits Form

    Dim buttonProperties As String(,) = {
    {"Button1", "Destination1", "Red"},
    {"Button2", "Destination2", "Green"},
    {"Button3", "Destination3", "Blue"},
    {"Button4", "Destination4", "Orange"},
    {"Button5", "Destination5", "Purple"},
    {"Button6", "Destination6", "Yellow"},
    {"Button7", "Destination7", "Cyan"},
    {"Button8", "Destination8", "Magenta"},
    {"Button9", "Destination9", "Pink"},
    {"Button10", "Destination10", "Brown"},
    {"Button11", "Destination11", "Teal"},
    {"Button12", "Destination12", "Lime"},
    {"Button13", "Destination13", "Indigo"},
    {"Button14", "Destination14", "Silver"},
    {"Button15", "Destination15", "Gold"},
    {"Button16", "Destination16", "Violet"},
    {"Button17", "Destination17", "Maroon"},
    {"Button18", "Destination18", "Navy"},
    {"Button19", "Destination19", "Olive"},
    {"Button20", "Destination20", "SkyBlue"}
    }

    Dim outputTextBox As New TextBox()
    Public Sub New()
        InitializeComponent()

        Dim xOffset As Integer = 10
        Dim yOffset As Integer = 10
        Dim buttonWidth As Integer = 100
        Dim buttonHeight As Integer = 30
        Dim formHeight As Integer = Me.Height

        For i As Integer = 0 To buttonProperties.GetLength(0) - 1
            Dim button As New Button()
            button.Text = buttonProperties(i, 0) ' Button name
            Dim buttonColor As Color = Color.FromName(buttonProperties(i, 2)) 'button color
            button.Location = New Point(xOffset, yOffset)
            button.Size = New Size(buttonWidth, buttonHeight)
            button.BackColor = buttonColor

            Dim propertyData As String() = {buttonProperties(i, 0), buttonProperties(i, 1), buttonProperties(i, 2)}

            AddHandler button.Click, Sub(sender, e) Button_Click(sender, e, propertyData)

            Me.Controls.Add(button)

            yOffset += buttonHeight + 5

            ' Check if adding the next button exceeds the form's height
            If yOffset + buttonHeight + 5 > formHeight Then
                xOffset += buttonWidth + 10 ' Move to the next column
                yOffset = 10 ' Reset the yOffset
                formHeight += buttonHeight + 5
                Me.Height = formHeight
            End If
        Next
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs, propertyData As String())
        Dim buttonName As String = propertyData(0)
        Dim destination As String = propertyData(1)
        Dim buttonColor As Color = Color.FromName(propertyData(2))
        outputTextBox.Multiline = True
        outputTextBox.Dock = DockStyle.Bottom
        outputTextBox.Height = 100 ' Adjust as needed
        Me.Controls.Add(outputTextBox)
        outputTextBox.AppendText("Button clicked: " & buttonName & Environment.NewLine)
        outputTextBox.AppendText("Destination: " & destination & Environment.NewLine)
        outputTextBox.AppendText("Button color: " & buttonColor.Name & Environment.NewLine)
    End Sub
End Class