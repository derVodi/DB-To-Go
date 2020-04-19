# DB-To-Go

## Abstract

This is a mini data warehouse on base of JPGs (the JPGs are in fact the data base - one JPG is one Record).
While the data can be hosted centralized, the viewing/managing can be done from different computers (synchronized).
It can even be used portable, because all you need is your JPGs plus one EXE (which is < 1 MB).

Example usage scenarios are: Manage your inventory, manage media collections (where media files or mediums are spread accross different carriers.)

## Download

Go here https://github.com/derVodi/DB-To-Go/releases and download the ZIP file under "Assets".

## Usage

###Local

* Create a directory for your "database"
** Put the DB-To-Go.exe into it
* Create a "Database" sub directory
** Put your images into it

###Network

* Create a file share for your "database"
** Put your images into it

Clients:

* Create an empty Database directory structure
* In the "Database" sub directory, edit the !DB-To-Go.d2g file
**Set SyncDir=\\Foo (where Foo is your UNC path to your file share)
