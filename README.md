# Root Insurance .net Core

This repository contains some of the product features I have learned over the last couple of weeks. It was inspired by an [OfferZen](https://www.offerzen.com/) make day.
The scope of the solution was to create a chat bot application that would enable a person to talk to the [Root Insurance Api](https://root.co.za/) and get a quotation on various offerings on Root's insurance platform.
Since I have not worked with [Google's DialogFlow](https://dialogflow.com/) yet, we decided (we were broken up in groups of 2 to 3 persons) to use DialogFlow as the chat platform.
Secondly I wanted to play with [Docker](https://www.docker.com/) and see if I can put down a .net Core Web Api on Linux and use this as the communication link between the chat bot and the Root Api. Since I needed
to save the state of the chat bot interactions, I also decided to play around with [RethinkDB](https://www.rethinkdb.com/) hosted in Docker.

I also made use of [ngrok](https://ngrok.com/) and will definitely use this tool again in future. 

This project is by no means complete yet and I think this might just be the starting point of it, but I think I did manage to get all the enviroments and Api's working without to much problems.

## Google DialogFlow
The first project is a chat bot created in **Google DialogFlow**. To get started with this, you need to create an account on Google DialogFlow. 
Once this is done you can create a new agent (don't use the V2 of the Api if you want to use the other projects).
Now you can click on the gear icon next to your Agent name on the left hand side and click on the "Export and Import" button.
Download the "DialogFlow Bot" chat bot folder, and Zip the contents of this folder. Now you can import it into DialogFlow just to see how I did some things.
After this is done, you can go to the fulfillment tab and enter your Web Api Address in there. Please check the section on ngrok to expose your site on https as this is a requirement

### Gotchas & Tips
The UI of DialogFlow and the documentation provided does not really match up that well. I also found that you should use one primary Web Browser Window to do the editing and saves of the project. I have not proved it, but it seems that the model is 
cached in the browser Window/Tab and if you click save on another older version of the project, it will overwrite some of the changes to older versions of the project.

Use the entities feature especially for yes/no questions. In this project there is a boolean entity with most of the yes and no answers a person can give. The entity value that gets passed back to the Api is then translated automatically into true or false and
this is quite usefull for Json.

When asking for numbers, the DialogFlow seems to accept **15K** or **15 thousand** as a number, but I couldn't quite get it to work with **million**. I am not sure if I did something wrong but it did accept **15M** as 15 million.
 
Then, try not to use follow up intents. If you start changing the contexts, the parent/child relationships keeps disappearing. It should in theory still work but if you are a bit OCD like me it might just ruin your day. Rather structure your
project and intents to use __Contexts__. This project has a main context named "root_context" that is available throughout the project and every answer the user gives will be recorded in the "root_context".
The way this works is simply as follows. On intents, you have input and output contexts. The intent(s) will become active as soon as all of its input contexts are available. Next, once an intent is satisfied with the response given by the user it
will output the contexts specified. You are also able to clear output contexts by clicking on the number of the context and simply changing the value to 0.

The easiest way I got this working is by asking the question in the previous intent and listening for an answer in the next intent. This can get a bit confusing so I suggest that you create your intents with a prefix to group them accordingly. Also remember to
give exact options on what the user is able to ask for, and try to keep the training as simple as possible. If there are two possible values with the word "insurance" in it, do not include that in the training engine as both options could pick this up and 
you might not get the flow of the dialog correct.

As a simple example, you would typically start with this.
* In the Welcome intent, you would typically greet the user and give a choice of options available. In the context out of this intent you would typically create your main context and the follow up context e.g. "root_context" and "option_context"
* Here there would be multiple intents (one for each option) that gets activated by the input contexts "root_context" and "option_context". On each of these intents the output context would be "root_context" and remove the "option_context" by setting the value to 0
  * Once any one of these option intents is satisfied, You would ask your first question regarding the question. You would then also add a new output context specific to the option e.g. "option_1_context" or "option_2_context"
* From here on out, just rinse and repeat.  

##ngrok


##More details to follow...