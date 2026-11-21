--ScenEdit_SpecialMessage('United States', 'Gameplay Notes:\n\nIntimidation is modeled. To attempt to intimidate a Bogey, approach it with one of your fighters with its air-to-air radar turned on. However, this may not always be effective.\n\nDo not allow Bogeys to enter the exclusion zone around the Battle Group.\n\nFollow the ROE. Remember, the goal of a Freedom of Navigation Exercise is political, not military.')
ScenEdit_MsgBox('Gameplay Notes:\n\nThe ROE that you have been given in the briefing is a different matter than the Doctrine ROE and refers to the actions that YOU order. (For example, by manual marking contacts, auto engaging targets, etc.) Follow the briefed ROE and expect that you may need to change some contacts between orange and red yourself as appropriate. Message boxes will pop-up to give clues whether Libyan aircraft may be considered hostile.\n\nIntimidation is modeled. To attempt to intimidate a Bogey, approach it with one of your fighters and be sure that its air-to-air radar turned on.\n\nDo not allow Bogeys to enter the exclusion zone around the task force.\n\nRemember, a big kill count is NOT the goal of a Freedom of Navigation exercise. This scenario emphasizes de-escalation.',1)
--ScenEdit_MsgBox ('If you value your career as a Naval Officer, do not allow Bogeys to enter a 35nm exclusion zone around the Nimitz!!!',1)

ScenEdit_SetKeyValue("tensionLevel","1")  --Represents how hostile Libya has chosen to be 1- turn away when confronted, 2- allows isolated air battle, 3- all-out war.   
ScenEdit_SetKeyValue("LibyaHasEngaged","0") --Represents if Libya is currently in an air-to-air battle in the context of tensionLevel 2   
ScenEdit_SetKeyValue("LibyaWasAggressor","0")  -- 1 to signal that aircraft were shot down as a result of Libyan, rather than US agression 
ScenEdit_SetKeyValue("unacceptableCasualties","0") --1 to signal that player's CAP mission failed




--These are to support a Special Action for the player to give limited control to an AI unit.
ScenEdit_SetKeyValue("AiUnitNeedsManualControl","0") --1 to trigger the code that sets manual Speed and Altitude for the AI-controlled Unit  
ScenEdit_SetKeyValue("AiUnitName","0") -- Name of the AI-controlled Unit neededing manual control 
ScenEdit_SetKeyValue("AiUnitManualSpeed","0") --manualSpeed to input to the AI-controlled unit 
ScenEdit_SetKeyValue("AiUnitManualAltitude","0") --manualAltitude to input to the AI-controlled unit
