LibyanContacts = ScenEdit_GetContacts('Libya') 
UnitedStatesContacts = ScenEdit_GetContacts('United States')  

for key,value in pairs(LibyanContacts) do
	
	--Check the Libya's contact emissions for the AWG-9 or AWG-10
	if value.emissions == nil then  
		--Prevents error being thrown before any emissions are detected
	elseif value.emissions[1].sensor_dbid == 2003 or value.emissions[1].sensor_dbid == 1443 then
		local USfighter = ScenEdit_GetUnit({guid = value.actualunitid})  
		
		--See if the unit associated with that radar is targeting any Libyan A/C
	    --If so, set that Libyan A/C RTB 
		for key_1, value_1 in pairs(UnitedStatesContacts) do 
			
			if value_1.type == nil then
				--Prevents error being thrown before types determined
			elseif value_1.type == 'Air' then
			
				local LibyanAircraft = ScenEdit_GetUnit({guid = value_1.actualunitid}) 
				local LibyanAircraftThreats = LibyanAircraft.targetedBy
				
				local closeDistance = 6
				local checkType = "init"
				
				if LibyanAircraft.dbid == 840 then --MiG-25Ps will try to fire BVR     
					closeDistance = 25
					checkType = "MiG-25"	
				elseif LibyanAircraft.dbid == 1208 or LibyanAircraft.dbid == 1351 then  --Mirage F.1EDs and  MiG-23MFs will try to fire to intermediate range
					closeDistance = 12
					checkType = "MiG-23/Mirage F.1"
				else   								--others close to heater range 
					closeDistance = 6 
					checkType = "Non BVR"
				end
				
				if LibyanAircraftThreats ~= nil then 
					for key_2, value_2 in pairs(LibyanAircraftThreats) do 
					
						if value_2 == USfighter.guid and Tool_Range(LibyanAircraft.guid, USfighter.guid) < closeDistance then
							ScenEdit_SetSidePosture("Libya","United States","H")
							ScenEdit_SetSidePosture("Libya","United States AI","H")
							ScenEdit_AttackContact(LibyanAircraft.guid, USfighter.guid ,{mode='0'})
							
							if ScenEdit_GetKeyValue("LibyaHasEngaged") == "0" then 
							
								miles = Tool_Range(LibyanAircraft.guid, USfighter.guid)
								ang = (3.2808399*USfighter.altitude/1000) --((3.2808399*USfighter.altitude)%1000)
								bear = Tool_Bearing (USfighter.guid, LibyanAircraft.guid)
								
								miles = string.format("%.1f", miles)
								ang = string.format("%.1f", ang)
								bear = string.format("%.1f", bear)  
								
								engDef = "Bear Ace this is "..USfighter.name..". Engaged defensive with a Bogey, bearing "..bear.." at "..miles..' miles out, Angels '..ang
							
								--ScenEdit_MsgBox (engDef, 1)
								--ScenEdit_SpecialMessage("United States", engDef.."  "..checkType)
								ScenEdit_SpecialMessage("United States", engDef)
							end
							
							ScenEdit_SetKeyValue("LibyaHasEngaged","1")
							
						end
					end
				end
			end
		end
	end
end


