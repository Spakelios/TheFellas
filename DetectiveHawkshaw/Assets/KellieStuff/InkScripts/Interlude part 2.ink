EXTERNAL Name(charName)

{Name("2009")}

<I>Life really couldn't be much better! A healthy family, a good job, a comfortable home.
<I>I spend my days working with my wife and see my friends often. 
<I>You know what's even better? She's heading straight for the top!
<I>No better woman for it either! And I get to be the lucky fella who gets to tell everyone-</I>
"That's my wife!"
<I> It's what she's always wanted and I get to support her every step of the way. I never had big plans or ambitions like her.
<I> She's amazing that way. Built for it, unlike myself.

{Name("2010")}

<I> I stare down at the documents on the desk, debating looking through them. I had some concerns to discuss with the Chief but... she seems to be out.
<I> I'm not really supposed to be in here... surely she'd understand. -> check

== check ==

* [ Inspect the documents ] -> inspect
* [ Trust the Chief ] -> trust 

=== inspect ===

<I> Unable to curb my curiousity I have a look through the documents strewn across her desk.
<I> ...I stare down at them in shock... mother of God. 
-> OhNo
== trust ===
<I> I can't simply refile through my boss' belongings! That's absurd! 
<I> ...I stare down at them nonetheless as the title of one of the papers catches my eye.
I just can't help myself, it'll just be a quick look. No harm in that, right? </I>
-> OhNo

=== OhNo ==

<I> It's all fake. Forgeries, copies of statements with large sums removed, hostile letters, photos of my coworkers' families.
<I>Each one had a name or face attached that I knew all so well.
<I> Before I know it, I'm digging through drawer after drawer.
<I> ...Even my own name, my wife's name and a picture of our daughter. I don't know whether to scream in anger or grief. The door cracks open. </I>

"May I ask what brings you to my office today, Emil?"

<I> I freeze, dropping whatever is in my hands. I had forgotten myself, forgotten my place, forgotten my purpose. I turn around. </I> -> wahh

== wahh ==

* [ Look away ]  -> two
* [ Stare ] -> four

 == two ==
  <I> <I> I can't look her in the eye, she can see right through me. I feel sick enough as it is. I can't bear to meet her gaze after what I've seen. </I> -> Continue
  
  == four ==
  <I>I look her dead in the eye, It's intimdating... far more than it's ever been.
...I avert my gaze soon after, she's far too intense.</I> 
  
  -> Continue
  
  == Continue ==
  
  "Find what you were looking for, did you?" <I> Her smile is unsettling. 
  I feel as though I should run, but my legs refuse to move. I can't run, this is all far too much. She moves closer, I hear a click. </I>
  "Boy. If you know what's good for you, you'll pretend you saw nothing here... I wasn't here and you left."
  
  <I>I can't do that, she's not helping anyone! It's all a set up... it's all fake..!</I>
  "...You won't get away with this..! I can't work with some no good cheat like you! All the lives you've ruined!"
  <I> I feel something cold against me. My mind goes fuzzy, I can't even think straight anymore. </I>
  
  "If you don't like it, then leave. Leave quietly and your wife can keep her job... leave peacefully and I won't release any of that little history of yours."
  
  
  {Name("2011")}
  
  <I> I lay my head on the desk. Newspapers with potential jobs circled in red lay strewn across the table amidsts the other rubbish.
  <I> I can't move, I can't think.
  <I> I don't want to. I try to stop thinking, my own thoughts frighten me. I have nothing left... it's over for me.
  <I> I failed everyone, my wife, my daughter and even myself.
  <I> My reputation was ruined, who would even hire me now?
  <I> I couldn't save anyone. 
  <I> I never deserved to be happy.
  <I> It was all fake.
  -> Drink 
  
  == Drink == 
  <I> I can hear rustling outside the door of my office. 
  
   * [ Not now! ] -> DrinkMore
   
   == DrinkMore == 
   <I> It's quickly followed by footsteps. 
   
    * [ Just go away already! ] -> DrinkEvenMore
         
== DrinkEvenMore ==
<I> Why is everything so damn loud!?
   
   * [ Shut up! ]  ->Help
  == Help ==
  
  "We're leaving..." "But... I wanna say goodbye to Dad! Where are we going? Mama?"
    <I> The door slams shut, the house falls quiet. It's for the best, I only hurt them.
      <I> All we did was fight nowadays, so I ran away from her.
      <I>They're better off without me. 
      
  <I> The door opens again. It's gentler this time, it doesn't hurt my ears. Has someone broken in?
  <I> I don't bother to check. I couldn't move, even if I wanted to.
  
  "...Emil? Emil are you alright!? Emil!"
  
  <I> I'm dragged out of the dark office and brought out to the light. It stings my eyes, and the friendly face that brought me out here stings them more.
  <I> In the light I know I can't hide... hide how pathetic and useless I've become.
  <I> Please don't look at me. Just put me back... 
  
  {Name("2013")} 
  
  <I> It takes time... so much time. 
  <I> I lost my home, a lot of my money, my wife, and I only see my daughter every other week, but I'm getting there.
  <I> I'm getting better everyday. If not for myself, then for my daughter.
  <I> If I wanted to keep seeing her, I needed a job.
  <I> So we've formed our own detective agency, it's small and people don't trust us yet, but it's enough.
  <I> Some days are a struggle, but I know I can make it, I have to.
  
  
-> END
