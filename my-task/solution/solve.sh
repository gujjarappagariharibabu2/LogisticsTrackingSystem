diff --git a/Services/ShipmentService.cs b/Services/ShipmentService.cs
index aeaf765..5568ae4 100644
--- a/Services/ShipmentService.cs
+++ b/Services/ShipmentService.cs
@@ -6,7 +6,9 @@ namespace LogisticsTrackingSystem.Services
     {
         public List<Shipment> GetActiveShipments(List<Shipment> shipments)
         {
-            return shipments;
+            return shipments
+                .Where(x => !x.IsArchived)
+                .ToList();
         }
     }
 }