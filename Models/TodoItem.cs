using System.ComponentModel.DataAnnotations;

namespace Models; 

public class TodoItem {
    [Key]
    public int ItemId {get;set;}
    
    [MaxLength(100)]
    public required string Title {get;set;}
    
    [MaxLength(500)]
    public string? Note {get;set;}
    
    public bool IsComplete {get;set;}
}