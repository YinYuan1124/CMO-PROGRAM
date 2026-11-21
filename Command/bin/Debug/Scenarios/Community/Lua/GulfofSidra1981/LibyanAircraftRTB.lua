LibyanContacts = ScenEdit_GetContacts('Libya') 
UnitedStatesContacts = ScenEdit_GetContacts('United States')  

for key,value in pairs(LibyanContacts) do
	
	--Check the Libya's contact emissions for the AWG-9 or AWG-10
	if value.emissions == nil then  
		--Prevents error being thrown before any emissions are detected
	elseif value.emissions[1].sensor_dbid == 2003 or value.emissions[1].sensor_dbid == 1443 then
		local USfighter = ScenEdit_GetUnit({guid = value.actualunitid})  
		local closeDistance =20
		
		--Libyans more "afraid"" of F-14's AWG-9 than the F-4's AWG-10
		if value.emissions[1].sensor_dbid == 2003 then 
			closeDistance = 30
		elseif value.emissions[1].sensor_dbid == 1443 then 
			closeDistance = 20
		end
		
		--See if the unit associated with that radar is targeting any Libyan A/C
	    --If so, set that Libyan A/C RTB 
		for key_1, value_1 in pairs(UnitedStatesContacts) do 
			
			if value_1.type == nil then
				--Prevents error being thrown before types determined
			elseif value_1.type == 'Air' then
			
				local LibyanAircraft = ScenEdit_GetUnit({guid = value_1.actualunitid}) 
				local LibyanAircraftThreats = LibyanAircraft.targetedBy
				
				if LibyanAircraftThreats ~= nil then 
					for key_2, value_2 in pairs(LibyanAircraftThreats) do 
					
						if value_2 == USfighter.guid and Tool_Range(LibyanAircraft.guid, USfighter.guid) < closeDistance then
							ScenEdit_SetUnit({guid = LibyanAircraft.guid, RTB = true})
						end
					end
				end
			end
		end
	end
end


