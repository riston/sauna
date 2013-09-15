Public Class Form1

    Dim time As DateTime = New DateTime
    Dim powerConsumption As Integer = 0

    ' Add the components into array
    Dim switchComponents As New List(Of RadioButton)
    Dim pickerComponents As New List(Of DateTimePicker)
    Dim componentPowerConsumptions = {8000, 110, 20, 400, 2000}

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Label2.Text = time.ToString

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        time = time.AddMinutes(36)

        HourLabel.Text = String.Format("{00}", time.Hour)
        MinuteLabel.Text = String.Format("{00}", time.Minute)
        PowerConsumptionLabel.Text = powerConsumption

        For index = 0 To switchComponents.Count - 1

            Dim switchButton As RadioButton = switchComponents.ElementAt(index)
            Dim picker As DateTimePicker = pickerComponents.ElementAt(index)

            If compareHourAndMinutes(time, picker.Value) And switchButton.Text = "Off" Then
                switch(switchButton, componentPowerConsumptions(index))
            End If
        Next
    End Sub

    Private Function compareHourAndMinutes(ByVal a As DateTime, ByVal b As DateTime) As Boolean
        If (a.Hour >= b.Hour And a.Minute >= b.Minute) Then
            Return True
        Else
            Return False

        End If
    End Function

    Private Sub heaterButton_Click(sender As Object, e As EventArgs) Handles heaterButton.Click
        switch(heaterButton, 8000)
    End Sub

    Private Sub switch(ByRef button As RadioButton, ByVal power As Integer)
        If button.Text = "Off" Then
            button.Text = "On"
            button.BackColor = Color.LightGreen
            powerConsumption += power
        Else
            button.Text = "Off"
            button.BackColor = Color.Gray
            powerConsumption -= power
        End If

    End Sub


    Private Sub CoffeemakerButton_Click(sender As Object, e As EventArgs) Handles CoffeemakerButton.Click
        switch(CoffeemakerButton, 400)
    End Sub

    Private Sub RadiatorButton_Click(sender As Object, e As EventArgs) Handles RadiatorButton.Click
        switch(RadiatorButton, 2000)
    End Sub

    Private Sub LightButton_Click(sender As Object, e As EventArgs) Handles LightButton.Click
        switch(LightButton, 20)
    End Sub

    Private Sub RefrigeratorButton_Click(sender As Object, e As EventArgs) Handles RefrigeratorButton.Click
        switch(RefrigeratorButton, 110)
    End Sub

    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        Timer1.Interval = TrackBar2.Value
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        switchComponents.Add(heaterButton)
        switchComponents.Add(RefrigeratorButton)
        switchComponents.Add(LightButton)
        switchComponents.Add(CoffeemakerButton)
        switchComponents.Add(RadiatorButton)

        pickerComponents.Add(HeaterDateTimePicker)
        pickerComponents.Add(RefigeratorDateTimePicker)
        pickerComponents.Add(LightDateTimePicke1)
        pickerComponents.Add(CoffeMakerDateTimePicker)
        pickerComponents.Add(RadiatorDateTimePicker)
    End Sub
End Class
