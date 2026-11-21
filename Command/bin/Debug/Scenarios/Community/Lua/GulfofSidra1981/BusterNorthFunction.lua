function BusterNorth(unitPartialName, loopStart, loopEnd, retreatLatitude, retreatLongitude, retreatSpeed, retreatAltitude)
	for i=loopStart, loopEnd do
		local unitToRetreatName = unitPartialName..i 
		local retreatPoint = {latitude = retreatLatitude, longitude = retreatLongitude }
		--local retreatPoint = {latitude = 32.50, longitude = 17.25 }
 
		if ScenEdit_GetUnit({name=unitToRetreatName, side='United States AI'}) ~= nil then
			local unitToRetreat = ScenEdit_GetUnit({name=unitToRetreatName, side='United States AI'})
	
			if unitToRetreat.airbornetime ~= "0" and unitToRetreat.unitstate ~= "RTB" and unitToRetreat.unitstate ~= "RTB_Manual" then 
				ScenEdit_SetUnit({side="United States AI", unitname=unitToRetreat.name, course = {{latitude=retreatPoint.latitude, longitude=retreatPoint.longitude, description = "Retreat"}}  })
				ScenEdit_SetUnit({side="United States AI", unitname=unitToRetreat.name, manualAltitude = "OFF",  manualSpeed = "OFF"})
				
				ScenEdit_SetKeyValue("AiUnitNeedsManualControl","1")
				ScenEdit_SetKeyValue("AiUnitName", unitToRetreat.name) 
				ScenEdit_SetKeyValue("AiUnitManualSpeed",retreatSpeed) 
				ScenEdit_SetKeyValue("AiUnitManualAltitude",retreatAltitude) 
			end
		end
	end
end