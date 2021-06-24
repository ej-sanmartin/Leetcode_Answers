/*
    You have a data structure of employee information, which includes the employee's    
    unique id, their importance value, and their direct subordinates' id.

    You are given an array of employees employees where:

    employees[i].id is the ID of the ith employee.
    employees[i].importance is the importance value of the ith employee.
    employees[i].subordinates is a list of the IDs of the subordinates of the ith    employee.
    
    Given an integer id that represents the ID of an employee, return the total 
    importance value of this employee and all their subordinates.
    
    T - O(n), where n is the number of employees, worst case we go through them all
    S - O(n), where n is the size of the dfs call stack
*/

/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/
class Solution {
    public int GetImportance(IList<Employee> employees, int id) {
        Dictionary<int, Employee> table = new Dictionary<int, Employee>();
        foreach(Employee employee in employees){
            table.Add(employee.id, employee);
        }
        return dfs(table, id);
    }
    
    private int dfs(Dictionary<int, Employee> table, int id){
        Employee employee = table[id];
        int totalImportance = employee.importance;
        
        foreach(int subordinateID in employee.subordinates){
            totalImportance += dfs(table,  subordinateID);
        }
        
        return totalImportance;
    }
}
