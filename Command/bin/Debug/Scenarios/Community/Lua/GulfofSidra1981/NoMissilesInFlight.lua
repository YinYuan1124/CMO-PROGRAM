--ScenEdit_RunScript('GulfofSidra1981/NoMissilesInFlight.lua')

usSide = VP_GetSide ({side="United States"})
usWeapons = usSide:unitsBy('Weapon')

usAISide = VP_GetSide ({side="United States AI"})
usAIWeapons = usAISide:unitsBy('Weapon')

LibyaSide = VP_GetSide ({side="Libya"})
LibyaWeapons = LibyaSide:unitsBy('Weapon')

if usWeapons == nil and usAIWeapons == nil and LibyaWeapons == nil then
	--ScenEdit_MsgBox ("No Missiles in flight TRUE", 1)
	return true
else 
	--ScenEdit_MsgBox ("No Missiles in flight FALSE", 1)
	return false
end