# MHW-Save-Editor
For research into the save file structure and modding in general visit the Monster Hunter World Modding Discord: https://discord.gg/gJwMdhK  
We are currently looking for code writers to implement additional sections that have already been mapped out.  
  
This is a MHW Save Editor. For the time being it allows changing the steam id (in case you want to use someone else's save), editing the investigation list, editing inventory, editing your name and resetting your edit voucher usage.

If you want to contribute the project is open to pull requests but is going to be phased out for a Python port in the near future. If you want to redistribute link to the releases section, DO NOT REUPLOAD THIS TO OTHER SITES.
  
Credit to:  
nexusphobiker - For figuring out the encryption function location in memory and having the first decrypter.  
legendff and Count Lizzie - For figuring out the encryption algorithm and the checksum.  
legendff - For getting all of the encryption keys from memory.  
Pascal/Ambytes - For writing the C# decryptor and checksum.  
AsteriskAmpersand - For rewriting the base GUI to support a complete editor, doing the save file investigation structure and investigation editor portion.  
Kaito - For helping testing and debugging the investigation editor and the new GUI. Also responsible for the backup and restore functionality.  
goose - For the appearance struct.  
V00d00y - For almost every other structure in the save files not found by the previously listed.  
V00d00y and Stratas - For robustness testing and the second for help with profiling performances.  
Seikur0 - For his tables which allowed V00d00y to do the above listed.  
W.EzeithLis - For his help with Investigation Box Rewards calculations.  
Digifreak and W.EzeithLis - For their help with zenny bonus calculations and tabulating.  
The investigation editor testers: AllStarTech, Kaito, nicemoreoften, Syelia Walldasher, W.EzeithLis, Digifreak, V00d00y, Stratas.  
The saves fallen in battle: nicemoreoften and Saddah.
