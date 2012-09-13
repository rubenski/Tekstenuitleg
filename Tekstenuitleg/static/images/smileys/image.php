<?php

$log = "iplog.txt";
$fh = fopen($log, 'a') or die("can't open file");
$pic = "";
if(isset($_GET['pic'])){
	$picName = $_GET['pic'];
}
if($_SERVER['REMOTE_ADDR'] != '85.144.203.130'){
	$logthis = date("F j, Y, g:i a") . "\n"; 
	$logthis .= "pic name: " . $picName . "\n";
	$logthis .= "referrer: " . $_SERVER['HTTP_REFERER'] . "\n";
	$logthis .= "ip: " . $_SERVER['REMOTE_ADDR'] . "\n";
	$logthis .= "user agent: " . $_SERVER['HTTP_USER_AGENT'] . "\n\n";

	fwrite($fh, $logthis);
	fclose($fh);
}

$image=imagecreatefromgif($picName .".gif");
header('Content-Type: image/gif');
imagegif($image);


/*
header( "Content-type: image/jpeg" );
ob_clean();
flush();
readfile("/smile.jpg);
exit;

*/

?>