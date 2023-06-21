using Code.ACE;
using Code.EK;
using Code.EKR;
using Code.GK;
using Graphs;
using JoinEntity;
using JoinEntityWithPayload;
using JoinEntityWithSkips;
using JoinEntityWithStringPayload;
using Notification;
using NWB;
using Optional;
using Proxies;
using Required;
using SP;
using Updates;

public class Program
{
    public static void Main()
    {
        //Explicit();
        //Access();
        //ChangeFK();
        //Detection();
        Identity();
    }

    public static void Identity()
    {
        //Console.WriteLine("Samples for _Identity Resolution in EF Core_");
        //Console.WriteLine();

        //IdentityResolutionSamples.Identity_Resolution_in_EF_Core_1();
        //IdentityResolutionSamples.Updating_an_entity_1();
        //IdentityResolutionSamples.Updating_an_entity_2();
        //IdentityResolutionSamples.Updating_an_entity_3();
        //IdentityResolutionSamples.Updating_an_entity_4();
        //IdentityResolutionSamples.Updating_an_entity_5();
        //IdentityResolutionSamples.Updating_an_entity_6();

        SerializedGraphExamples.Attaching_a_serialized_graph_1();
        SerializedGraphExamples.Attaching_a_serialized_graph_2();
        SerializedGraphExamples.Attaching_a_serialized_graph_3();
        SerializedGraphExamples.Attaching_a_serialized_graph_4();
        SerializedGraphExamples.Attaching_a_serialized_graph_5();

        IdentityResolutionSamples.Failing_to_set_key_values_1();
    }

    public static void Detection()
    {
        Console.WriteLine("Samples for _Change Detection and Notifications_");
        Console.WriteLine();
        Snapshot.Snapshot_change_tracking_1();
        Snapshot.Snapshot_change_tracking_2();

        NotificationEntities.Notification_entities_1();
        NotificationWithBase.Notification_entities_2();
        ChangeTrackingProxies.Change_tracking_proxies_1();
    }

    public static void ChangeFK()
    {
        Console.WriteLine("Samples for _Changing Foreign Keys and Navigations_");
        Console.WriteLine();

        OptionalRelationships.Relationship_fixup_1();
        OptionalRelationships.Relationship_fixup_2();

        OptionalRelationships.Changing_relationships_using_navigations_1();
        OptionalRelationships.Changing_relationships_using_navigations_2();

        OptionalRelationships.Changing_relationships_using_foreign_key_values_1();

        OptionalRelationships.Fixup_for_added_or_deleted_entities_1();
        OptionalRelationships.Fixup_for_added_or_deleted_entities_2();
        OptionalRelationships.Fixup_for_added_or_deleted_entities_3();
        RequiredRelationships.Fixup_for_added_or_deleted_entities_4();
        RequiredRelationships.Fixup_for_added_or_deleted_entities_5();
        RequiredRelationships.Fixup_for_added_or_deleted_entities_6();
        OptionalRelationships.Fixup_for_added_or_deleted_entities_7();
        RequiredRelationships.Fixup_for_added_or_deleted_entities_8();

        OptionalRelationships.Deleting_an_entity_1();
        RequiredRelationships.Deleting_an_entity_2();

        ExplicitJoinEntity.Many_to_many_relationships_1();
        ExplicitJoinEntity.Many_to_many_relationships_2();
        ExplicitJoinEntityWithSkips.Many_to_many_relationships_3();
        ExplicitJoinEntityWithSkips.Many_to_many_relationships_4();
        ExplicitJoinEntityWithSkips.Many_to_many_relationships_5();
        OptionalRelationships.Many_to_many_relationships_6();
        ExplicitJoinEntityWithPayload.Many_to_many_relationships_7();
        ExplicitJoinEntityWithStringPayload.Many_to_many_relationships_8();
        ExplicitJoinEntityWithStringPayload.Many_to_many_relationships_9();
    }

    public static void Access()
    {
        Console.WriteLine("Samples for _Accessing Tracked Entities_");
        Console.WriteLine();

        AccessingTrackedEntities.Using_DbContext_Entry_and_EntityEntry_instances_1();
        AccessingTrackedEntities.Work_with_the_entity_1();
        AccessingTrackedEntities.Work_with_the_entity_2();
        AccessingTrackedEntities.Work_with_a_single_property_1();
        AccessingTrackedEntities.Work_with_a_single_navigation_1();
        AccessingTrackedEntities.Work_with_a_single_navigation_2();
        AccessingTrackedEntities.Work_with_all_properties_of_an_entity_1();
        AccessingTrackedEntities.Work_with_all_navigations_of_an_entity_1();
        AccessingTrackedEntities.Work_with_all_members_of_an_entity_1();

        AccessingTrackedEntities.Find_and_FindAsync_1();
        AccessingTrackedEntities.Find_and_FindAsync_2();

        AccessingTrackedEntities.Using_ChangeTracker_Entries_to_access_all_tracked_entities_1();

        AccessingTrackedEntities.Using_DbSet_Local_to_query_tracked_entities_1();
        AccessingTrackedEntities.Using_DbSet_Local_to_query_tracked_entities_2();
        AccessingTrackedEntities.Using_DbSet_Local_to_query_tracked_entities_3();
        AccessingTrackedEntities.Using_DbSet_Local_to_query_tracked_entities_4();
    }

    public static void Explicit()
    {
        Console.WriteLine(" for _Change Tracking in EF Core_");
        Console.WriteLine();

        GeneratedKeys.Simple_query_and_update_1();
        GeneratedKeys.Simple_query_and_update_2();
        GeneratedKeys.Query_then_insert_update_and_delete_1();

        ExplicitKeys.Inserting_new_entities_1();
        ExplicitKeys.Inserting_new_entities_2();
        GeneratedKeys.Inserting_new_entities_3();

        ExplicitKeys.Attaching_existing_entities_1();
        ExplicitKeys.Attaching_existing_entities_2();
        GeneratedKeys.Attaching_existing_entities_3();

        ExplicitKeys.Updating_existing_entities_1();
        ExplicitKeys.Updating_existing_entities_2();
        GeneratedKeys.Updating_existing_entities_3();

        ExplicitKeys.Deleting_existing_entities_1();
        ExplicitKeys.Deleting_dependent_child_entities_1();
        ExplicitKeys.Deleting_dependent_child_entities_2();
        ExplicitKeys.Deleting_principal_parent_entities_1();
        ExplicitKeysRequired.Deleting_principal_parent_entities_1();

        GeneratedKeys.Custom_tracking_with_TrackGraph_1();
    }
}