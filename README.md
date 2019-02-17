# CodeFellowGram

**Deployed URL: https://codefellowgram-mbg.azurewebsites.net/**

Welcome to my Code Fellows themed social media app! Using Azure blob storage, SQL databases, and Razor Pages, users can share their life experience through pictures and captions, as well as leave comments to start a discussion. Users can create new posts, or edit existing ones, as well as delete a post. Comments can be created and are unique to each post. Pictures are uploaded from the user to the Azure blob container where they are stored and retreived via URL. Each post object, along with its comments, are stored in the SQL database. 

## How to Use
Viewing a post
* The main page will show the collection of posts made on CodeFellowGram from newest to oldest, displaying a picture and the name of the user who posted it. Clicking on an image will direct you to a details page, showing any caption the user made for the image and any comments made on the post.

Adding a post
* On the main page, click on the button labeled "NEW POST" at the top or the bottom of the page. You will be directed to a form with fields labeled to request your name, image to upload from your local storage, and an optional caption to add to your post. When you are finished, click the save button and you will be directed to your new post.

Editing a post
* From the main page, click on the image of the post to wish to edit. In the details page of that post, click the button below the post labeled "EDIT". You will be directed to the a page with the same fields for adding a new post but filled with that posts details. Change the information as you wish and click "SAVE" when you are done.

Deleting a post
* As with editing a post, go to the details page of that post and click "EDIT". Once at the editing page, click the button labeled "DELETE". This will delete the selected post and send you back to the home page where that post will no longer be visible.

Commenting on a post
* When selecting a post to view its details, click the button labeled "ADD COMMENT". You will be directed to a page with fields to enter your username and the message you would like to add to the post. When finished, click "SAVE" and you will be directed to the details page of that post where you can view your new comment. 

## Screenshots
**Front Page**
![front page](https://github.com/mbgoseco/CodeFellowGram/blob/master/Assets/FrontPage.PNG)

**Post Details**
![details](https://github.com/mbgoseco/CodeFellowGram/blob/master/Assets/Details.PNG)

**Adding or Editing a Post**
![add or edit post](https://github.com/mbgoseco/CodeFellowGram/blob/master/Assets/AddOrEdit.PNG)

**Adding a Comment to a Post**
![adding comment](https://github.com/mbgoseco/CodeFellowGram/blob/master/Assets/Comment.PNG)

## Schema
![Database Schema](https://github.com/mbgoseco/CodeFellowGram/blob/master/Assets/CodeFellowGram.png)

**Post**
* ID - Primary Key
* Author - Username of person creating the post
* ImageURL - The image from user's local storage that will be uploaded to Azure blob and displayed on the post
* Caption - Text that the user may add in addition to their picture

**Comment**
* ID - Primary Key
* PostID - Foreign Key - A key value that associates a generated comment to its designated post
* User - Name of user creating the comment
* UserComment - Text field where the user makes their comment for the post

## Technologies Used
ASP.NET Core, Razor Pages, SQL Databases, Azure web app deployment, Azure blob storage
