function changeView(_index)
{
	var nv = document.getElementById("showView");
	switch(_index) 
	{
		case 1: 
			nv.setAttribute("src","additem.html");
			break;
		case 2:
			nv.setAttribute("src","addtype.html");
			break;		
		case 3:
			nv.setAttribute("src","showitem.html");
			break;
		case 4:
			nv.setAttribute("src","setting.html");
			break;	
		default: 
			break;
	}
}