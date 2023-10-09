--=================================================                    
-- CREATED BY  : Waqas Yaqoob                    
-- CREATED ON  : 20-07-2023                    
-- DESCRIPTION : GetAll FOR Alerts        
--==================================================           
CREATE PROCEDURE sjc_GetAllAlerts        
@userid int = NULL              
AS              
BEGIN              
 Select               
  AlertId,        
case when AlertType = 'E' then 'Email' end AlertType,        
Subject,        
Email,        
MobileNo,        
Message,        
CreatedBy,        
CreatedDate,        
LastModifiedBy,        
LastModifiedDate,        
Deleted,        
UserId,    
IsViewed,    
cast(ViewedOn as date) as ViewedOn    
 From Alerts        
 Where userid = ISNULL(@userid, userid)   ;  
  
   IF @userid IS NOT NULL AND @userid <> 0  
    BEGIN  
        UPDATE Alerts  
        SET  
            ViewedOn = GETDATE(),  
            LastModifiedBy = @userid,  
            LastModifiedDate = GETDATE(),  
            IsViewed = 1  
        WHERE  
            UserId = @userid;  
    END;  
END        