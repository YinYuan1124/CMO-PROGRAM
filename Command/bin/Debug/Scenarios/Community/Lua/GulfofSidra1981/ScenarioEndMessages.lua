playerScore = ScenEdit_GetScore("United States")

failureMessage = "Overall, your performance has seriously harmed the national security interests of the United States. Rather than establish Freedom of Navigation, your disastrous mission has only served as a propaganda coup for Muammar Gaddafi. Citing “unprovoked imperialist aggression,” Gaddafi uses this day’s events to underscore how vital his territorial claims are for Libya’s security. In the following months and years, various non-aligned and communist nations, with the backing of the Soviet Union- and the tacit support of even some NATO allies- begin a push in the United Nations to rewrite the UN Convention on the Law of the Sea (UNCLOS). All over the world, various “carrier-free zones” arise, specifically designed to keep the claimants permanently out of <legal> reach of carrier strike aircraft. Although the U.S. itself does not ratify the new convention, the increased hostility from the international community is an undesirable outcome. " 

--partialfailureMessage1 = "The situation escalated too much but we can blaim it on Libya"
partialfailureMessage1 = "The situation escalated far beyond what was intended for the exercise, with both sides initiating hostility against the other at some point. In the aftermath, both sides will blame each other on the international stage, with Gaddafi claiming “imperialist aggression,” and Reagan citing “unprovoked hostile action by a dangerous regime in clear violation of international law.” Ultimately, the incident will come to be seen as something of a draw, but with United States losing some confidence and far less willing to conduct further Freedom of Navigation exercises for many years." 

partialfailureMessage2 = "The Freedom of Navigation exercise generally succeeded, but you failed to sufficiently protect valuable assets as you were ordered, thus ending your career in the Navy."

careerSalvagedMessage = " However, your personal performance during the exercise will be officially investigated and subject to criticism for the rest of your career, though you will somehow avoid the dreaded ‘Letter of Reprimand’, if for no reason other than to avoid strengthening Gaddafi’s case."
careerFaillureMessage = " However, you failed to sufficiently protect valuable assets as you were ordered, thus ending your career in the Navy."

successMessage = "You have succeeded in fending off Libyan aggression while preventing the situation from escalating to a dangerous level. The Freedom of Navigation exercise has been a success and accomplished its political objectives. Well done. "

scoreUS = ScenEdit_GetScore("United States")


if ScenEdit_GetKeyValue("tensionLevel") == "3" then

	if ScenEdit_GetKeyValue("LibyaWasAggressor") == "0"  then
		ScenEdit_SpecialMessage('United States', failureMessage)
		
	elseif ScenEdit_GetKeyValue("LibyaWasAggressor") == "1" then 
			if ScenEdit_GetKeyValue("unacceptableCasualties") == "0" then  
				ScenEdit_SpecialMessage('United States', partialfailureMessage1..careerSalvagedMessage)
			elseif ScenEdit_GetKeyValue("unacceptableCasualties") == "1" then 
				ScenEdit_SpecialMessage('United States', partialfailureMessage1..careerFaillureMessage)
			else
				ScenEdit_SpecialMessage('United States', "Problem with unacceptableCasualties variable")
			end
	else	
		ScenEdit_SpecialMessage('United States', "Problem with LibyaWasAggressor variable")
	end

else
	if ScenEdit_GetKeyValue("unacceptableCasualties") == "0" then
		scoreUS = scoreUS +100 
		ScenEdit_SetScore("United States", scoreUS, "Freedom of Navigation Exercise Successful")
		ScenEdit_SpecialMessage('United States', successMessage)
	elseif ScenEdit_GetKeyValue("unacceptableCasualties") == "1" then  
		ScenEdit_SpecialMessage('United States', partialfailureMessage2)
	else
		ScenEdit_SpecialMessage('United States', "Problem with unacceptableCasualties variable")
	end

end

