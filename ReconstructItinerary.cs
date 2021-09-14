/*
    You are given a list of airline tickets where tickets[i] = [fromi, toi] represent the departure and the 
    arrival airports of one flight. Reconstruct the itinerary in order and return it.

    All of the tickets belong to a man who departs from "JFK", thus, the itinerary must begin with "JFK". If 
    there are multiple valid itineraries, you should return the itinerary that has the smallest lexical order 
    when read as a single string.

    For example, the itinerary ["JFK", "LGA"] has a smaller lexical order than ["JFK", "LGB"].
    You may assume all tickets form at least one valid itinerary. You must use all the tickets once and only once.

    T - O(E logE/V), sorting each linked list is a costly operation
    S - O(V + E), creating the adjacency list
*/
public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) {
        Dictionary<string, LinkedList<string>> flights = new Dictionary<string, LinkedList<string>>();
        LinkedList<string> route = new LinkedList<string>();
        
        // create graph
        foreach(List<string> ticket in tickets){
            string origin = ticket[0];
            string destination = ticket[1];
            if(flights.ContainsKey(origin)){
                LinkedList<string> destinationList = flights[origin];
                destinationList.AddFirst(destination);
            } else {
                LinkedList<string> destinationList = new LinkedList<string>();
                destinationList.AddFirst(destination);
                flights.Add(origin, destinationList);
            }
        }
        
        // sort graph, C# is convoluted with sorting linked list
        string[] airports = flights.Keys.ToArray(); // get all vertices
        for(int i = 0; i < airports.Length; i++){ // for loop since can't change values with foreach
            string airport = airports[i];
            LinkedList<string> flight = flights[airport]; // grab linked list
            flight = new LinkedList<string>(flight.OrderBy(x => x)); // sort with LINQ, and set to new linked list
            flights[airport] = flight;
        }
        
        DFS(flights, route, "JFK");
        return route.ToList();
    }
    
    public void DFS(Dictionary<string, LinkedList<string>> flights, LinkedList<string> route, string origin){
        if(flights.ContainsKey(origin)){
            LinkedList<string> destinationList = flights[origin];
            while(destinationList.Count != 0){
                string destination = destinationList.First.Value;
                destinationList.RemoveFirst();
                DFS(flights, route, destination);
            }
        }
        route.AddFirst(origin);
    }
}
