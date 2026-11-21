--This script should trigger if a Libyan Aircraft is shot down during tensionLevel == 1, i.e. the U.S. fired first

function releaseScrambleFighters() 
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 201', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 202', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 203', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 204', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 205', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 206', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 207', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_SetLoadout ({UnitName='Jolly Roger 208', LoadoutID=0, TimeToReady_Minutes=0})
	ScenEdit_MsgBox ('VF-84 has been released for emergency fleet defense.',1)  
	return true
end

    scoreUS = ScenEdit_GetScore("United States")  

if ScenEdit_GetKeyValue("LibyaWasAggressor") == '0' then

	--ScenEdit_MsgBox ('Either you have violated the ROE, or your performance has placed your superiors in a position where they had to decide to open fire on Libyan aircraft. Now, SIGINT suggests that a major Libyan retaliation strike is underway. That the United States technically fired first will have major political consequences, but for now you must prepare to defend the fleet.', 1)
	ScenEdit_SpecialMessage('United States','Either you have violated the ROE, or your performance has placed your superiors in a position where they had to decide to open fire on Libyan aircraft. Now, SIGINT suggests that a major Libyan retaliation strike is underway. That the United States technically fired first will have major political consequences, but for now you must prepare to defend the fleet.')
	ScenEdit_AddCustomLoss("United States", {{"Your career in the Navy", 1}})
	scoreUS = scoreUS - 100
	ScenEdit_SetScore ('United States', scoreUS, 'ROE violation')

elseif ScenEdit_GetKeyValue("LibyaWasAggressor") == '1' then 
	--ScenEdit_MsgBox ('Prior Libyan aggression has combined with a jittery American air defense to result in the shoot-down of an aircraft whose justification is dubious at best. Now, SIGINT suggests that a major Libyan retaliation strike is underway. Today’s actions will result in numerous Congressional investigations in the coming months, but for now you must prepare to defend the fleet.', 1)
	ScenEdit_SpecialMessage('United States','Prior Libyan aggression has combined with a jittery American air defense to result in the shoot-down of an aircraft whose justification is dubious at best. Now, SIGINT suggests that a major Libyan retaliation strike is underway. Today’s actions will result in numerous Congressional investigations in the coming months, but for now you must prepare to defend the fleet.')
	scoreUS = scoreUS - 50
	ScenEdit_SetScore ('United States', scoreUS, 'ROE violation with mitigating circumstances')
	
else
	ScenEdit_MsgBox ('LibyaWasAggressor == '..ScenEdit_GetKeyValue("LibyaWasAggressor"), 1)
end

ScenEdit_SetKeyValue("tensionLevel","3")
ScenEdit_SetSidePosture("Libya","United States","H")
ScenEdit_SetSidePosture("Libya","United States AI","H")
ScenEdit_SetSidePosture("United States","Libya","H")
ScenEdit_SetSidePosture("United States AI","Libya","H")


releaseScrambleFighters()









