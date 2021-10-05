<html>
<head>
<title>The Official Site Of Will Lucifer Jasen</title>

<STYLE TYPE="text/css"> 
<!-- 
A:visited {text-decoration: none; color: 00ff00} 
A:hover {text-decoration: none; color: red}
A:link {text-decoration: none; color: 00ff00} 
A:active {text-decoration: none; color: red} 
.textbox {
border-style: none;
background: transparent;
}
--> 
</STYLE>

<style>
body 
{ 
scrollbar-base-color: #cccccc; 
scrollbar-face-color: #000000; 
scrollbar-track-color: #000000; 
scrollbar-arrow-color: #cccccc;
scrollbar-highlight-color: #cccccc; 
scrollbar-3dlight-color: #555555; 
scrollbar-shadow-color: #cccccc;
scrollbar-darkshadow-color: #666666; 
} 
</STYLE>

</head>

<body bgcolor=#000000 leftmargin="20" rightmargin="0" topmargin="20" bottommargin="20">

<table width=400 cellpadding=3 cellspacing=0 style="border: 1px solid #cccccc">
<tr><td colspan="2" bgcolor=#000000 align=right>

<font face=verdana size=1 color=cccccc>

<b>Numbers</b>

<tr><td style="border-top: 1px solid #cccccc" bgcolor=#000000>

<font face=verdana size=1 color=ff0000>

<?php
$total=$_POST["total"];
$x=10; $y=20; $z=1; $num1; $num2; $i=1;
$total-=25;	
for ($i=1; $i<11; $i++)
{
	if (($x<$total) && ($total<$y))
		{
			$num1=$z; $x=1;
		}
	else 
		{
            		$x+=10; $y+=10; $z+=1;
        	}
}
$z=1;
for ($i=1; $i<10; $i++)
{
	if (($total-$x)%10==0)
		{
			$num2=$z;
		}
	else 
		{
            		$x+=1; $z+=1;
        	}
}
?> 
Your first number is: <?php echo "$num1"; ?><br />
Your second number is: <?php echo "$num2"; ?><br />
<php $_POST=""; ?>
<br><br>
<a href="/numbers.html" target=main>Go back and try again!</a>

</table><br>

