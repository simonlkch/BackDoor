//test pasuethread


set dm = createobject("dm.dmsoft")
dm.SetPath "E:\Program Files\QM"
dm.SetDict 0, "Ran.txt"

Delay 3000
dm_ret = dm.SetWindowSize(hwnd,300,400) //windowsize to smallest
//Call Login()

idhp = BeginThread(hp)
idFight = BeginThread(Fight)
idtime = BeginThread(thisistimeOK)
idreborn = BeginThread(reborn)
idpeteat = BeginThread(peteat)
idnoWater = BeginThread(noWater)

Delay 15000
set dm = createobject("dm.dmsoft")
dm.SetPath "E:\Program Files\QM"
dm.SetDict 0, "Ran.txt"
hwnd = dm.GetMousePointWindow()
dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
Delay 2000
MessageBox "Complete Loading"

Do	
	Delay 1000	
	Call findCancelBtn()
	Call showTheMoneyOnTitle()
Loop

//300
Sub hp()
	set dm = createobject("dm.dmsoft")
	hwnd = dm.GetMousePointWindow()
	dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
	Delay 1000


Do
dm.KeyPress 65
Delay 300
loop
End Sub 

Sub Fight()
	//邦定
	// ff0000-000000 red
	// b8b8b8-000000
	
	//48,72,2000,2000 打怪
	// 86,89,680,513 中間
	
	//119,107,663,437
	Delay 3000
	
	set dm = createobject("dm.dmsoft")
	hwnd = dm.GetMousePointWindow()
	
	dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
	Do
	dm_ret = dm.FindColor(119,107,663,437,"ff0000-000000",1.0,4,intX,intY)
	If intX >= 0 and intY >= 0 Then 	
		Randomize
		ranDomX = Int(10 * Rnd) //RamdomforX
		ranDomY = Int(10 * Rnd) //RamdomforY
    	Randomize
		Delay 100
		s=10*Rnd(100)+48
		dm.KeyPress s
		Delay 100			
		dm.MoveTo intX + ranDomX, intY + ranDomY	 	 	
		Delay 100    	 
		dm.RightClick
		Delay 100	
		Randomize
		Delay 100
		s=10*Rnd(100)+48
		dm.KeyPress s
		Delay 100
		dm.MoveTo intX - ranDomX, intY - ranDomY	 	 	
		Delay 100    	
		dm.RightClick 
		Delay 100
		//
	End If
	
	Loop
End Sub

Sub thisistimeOK()
	Delay 7000
	set dm = createobject("dm.dmsoft")
	hwnd = dm.GetMousePointWindow()
	dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
	Do
	For 1200
		Delay 1000
	Next
	
	PauseThread idreborn
	PauseThread idpeteat
	PauseThread idnoWater
	
	dm.keyPress 83 //回起點
	
	For 12
		Delay 1000
	Next
	dm.moveTo 466, 6
	dm.leftClick
	dm.keyPress 106//num *制
	Delay 1000
	dm.keyPress 81//回打怪點
	dm.keyPress 81//回打怪點
	dm.keyPress 81//回打怪點
	
	dm.keyPress 106//num *制	
	dm.keyPress 81//回打怪點
	dm.keyPress 81//回打怪點
	dm.keyPress 81//回打怪點
	
	ContinueThread idreborn
	ContinueThread idpeteat
	ContinueThread idnoWater
	Loop
		
End Sub

Sub Login()
dm.RunApp "E:\Program Files\Ran\Launcher.exe",0
Delay 3000
MoveTo 594, 431
LeftClick 1
Delay 5000
hwnd = dm.GetMousePointWindow()
dm_ret = dm.SetWindowState(hwnd, 1)

dm_ret = dm.BindWindow(hwnd, "dx", "normal", "normal", 0)
Delay 4000
dm_ret = dm.FindStr(0,0,2000,2000,"香港","d3d3d3-000000",1.0,intX,intY)
If intX >= 0 and intY >= 0 Then
     dm.MoveTo intX, intY
     dm.LeftClick 
     Delay 1000
     	dm_ret = dm.FindStr(0, 0, 2000, 2000, "PK", "d3d3d3-000000", 1.0, x, y)
     	If x > 0 Then 
     	dm.MoveTo x, y
     	dm.LeftClick
     	 	Delay 1000
     		dm_ret = dm.FindStr(0, 0, 2000, 2000, "連線", "d3d3d3-000000", 1.0, Cx, Cy)
			dm.MoveTo Cx, Cy
			dm.LeftClick 
			Delay 500
			Call AccountNumber()
			KeyPress "Tab", 1
			Delay 100
			Call Password()
			Delay 200
			KeyPress "Enter", 1
			Call Password()		
			Delay 3000
			dm.MoveTo 231,326
			dm.LeftClick 
			dm.LeftClick 
			Delay 10000
			dm.keyPress 68
			Delay 100
//			Call checkWhere()
			
			dm_ret = dm.UnBindWindow()		 
			Delay 3000
						
			hwnd = dm.GetMousePointWindow()
			dm_ret = dm.SetWindowState(hwnd,1)
			dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
			Delay 500
			
//			idHP = BeginThread(HP)
//			Delay 1000
//			idFight = BeginThread(Fight)
//			Delay 1000
//			idGOTOHOME = BeginThread(GOTOHOME)
     	End If
End If
End Sub

Sub AccountNumber()
	KeyPress "S", 1
  // enter by keypress
End Sub

Sub Password()
	Delay 200
	KeyPress "G", 1
  // enter by keypress
End Sub

Sub checkWhere()
	set dm = createobject("dm.dmsoft")
	hwnd = dm.GetMousePointWindow()	
	dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
	Delay 1000
	
	
	dm_ret =dm.FindStr(0, 0, 2000, 25, "聖門學院", "ffffff-000000", 1.0,x, y)
	If x > 0 Then 
		For 10
	 	Delay 1000
	 	Next
	 	dm.moveto 400, 300
	 	dm.LeftClick 
	 	Delay 100
	 	dm.LeftClick
	dm.keyPress 81 
	dm.keyPress 81

	End If

End Sub

Sub pkTime()
    dm_ret =dm.FindStr(0, 0, 2000, 2000, "PK時段已開始", "87cefa-000000", 1.0, x, y)
		If x > 0 Then 
				
		dm_ret =dm.FindStr(0, 0, 2000, 25, "聖門學院", "ffffff-000000", 1.0, Sx, Sy)
			If Sx < 0 Then 
    		dm.KeyPress 83
    		dm.KeyPress 83
    		dm.KeyPress 83
    		Delay 1800000
 
    		dm.keyPress 86 //v
			dm.keyPress 86
			dm.keyPress 86
			dm.keyPress 86
			dm.keyPress 86
			dm.keyPress 86
			dm.KeyPress 81//PreviousPoint
			dm.KeyPress 81
			dm.KeyPress 81
			
	End If
    End If
    End Sub

Sub reborn()
	Delay 9000
	set dm = createobject("dm.dmsoft")
	dm.SetPath "E:\Program Files\QM"
	dm.SetDict 0, "Ran.txt"
	hwnd = dm.GetMousePointWindow()
	dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
	
	Do
		dm_ret = dm.FindStr(0, 0, 2000, 2000, "經驗值恢復", "d3d3d3-000000", 1.0, RX, RY)
		If RX > 0 Then 

			Delay 1000
			dm.MoveTo RX - 88, Ry
			dm.leftClick 
			Delay 100
			dm.leftClick 
			PauseThread idtime
			Delay 60000	
			dm.KeyPress 81 //Q 回前點
			dm.KeyPress 81
			dm.KeyPress 81
			dm.KeyPress 81
			dm.KeyPress 81
			For 60 //wait 1min
				Delay 1000
			Next
			ContinueThread idtime
		Else 

			For 10//5mis
				Delay 1000
			Next
		End If
	Loop
End Sub

Sub peteat()
Delay 11000
set dm = createobject("dm.dmsoft")
dm.SetPath "E:\Program Files\QM"
dm.SetDict 0, "Ran.txt"
hwnd = dm.GetMousePointWindow()
dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
Delay 2000


For 21600 //6hrs
	Delay 1000
Next
dm.keypress 68//D
Delay 1000
dm.keypress 69//E

For 21600 //6hrs
	Delay 1000
Next
dm.keypress 69//E
Delay 1000
dm.keypress 87//W

//i = 0

//Do Until i=2
//dm_ret = dm.FindStr(0,0,2000,2000,"寵物無法進行活動","ff0000-000000",1.0,petX,petY)
//If petX >= 0 Then
// Select Case i
// 	Case 0
// 		dm.keypress 68//D
// 		For 3600
// 		Delay 1000
// 		Next
// 	Case 1
// 		dm.keypress 87//W
// End Select
// i = i + 1
// Else 
// Delay 1000
//End If
//Loop

End Sub

Sub OnScriptExit()

   dm.UnBindWindow

End Sub

Sub noWater()
	Delay 13000
	set dm = createobject("dm.dmsoft")
	dm.SetPath "E:\Program Files\QM"
	dm.SetDict 0, "Ran.txt"
	hwnd = dm.GetMousePointWindow()
	dm_ret = dm.BindWindow(hwnd, "dx", "dx2", "dx", 0)
	Delay 1000
	Do
		dm_ret = dm.FindStr(0, 0, 2000, 2000, "無法使用藥水", "98fb98-000000", 1.0, RX, RY)
		If RX > 0 Then 
				dm.keyPress 83 //回起點
				dm.keyPress 83 //回起點
				PauseThread idtime
				For 60
					Delay 1000
				Next
				dm.keyPress 106//num *制
				Delay 1000
				dm.keyPress 81//回打怪點
				dm.keyPress 81//回打怪點
				dm.keyPress 81//回打怪點
				
				dm.keyPress 106//num *制	
				dm.keyPress 81//回打怪點
				dm.keyPress 81//回打怪點
				dm.keyPress 81//回打怪點
				For 60 //wait for1 min
					Delay 1000
				Next
				ContinueThread idtime
		End If
	Loop
End Sub

Sub findCancelBtn()
	Delay 1000
	dm_ret = dm.FindStr(0, 0, 2000, 2000, "取消", "d3d3d3-000000", 1.0, RX, RY)
		If RX > 0 Then 
		dm.moveto RX, RY
		dm.leftclick 
		End If
	dm_ret = dm.FindStr(0, 0, 2000, 2000, "否", "d3d3d3-000000", 1.0, RX, RY)
		If RX > 0 Then 
		dm.moveto RX, RY
		dm.leftclick 
		End If	
End Sub

Sub showTheMoneyOnTitle()
	
txt = Plugin.Memory.Read32Bit(Hwnd, &H02D1FF00)

If Len(txt) >= 6 Then 
For n = Len(txt) - 3 To 1 Step - 3 
Txt = Left(txt, n) & "," & Right(txt, Len(txt) - n)
Next
ElseIf Len(txt) >= 4 Then
txt = Left(txt, Len(txt) - 3) & "," & Right(txt, 3)
End If

dm_ret = dm.SetWindowText(hwnd, "你的金錢有: " & Txt)
Delay 1000
End Sub
