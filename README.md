## Inspiration

The Sale Deed Registry, A based smart contract application was inspired by the "Indian" government. Currently, most of these aspects are done with the combination of tons of paper work and some electronic. Though few states went ahead and implemented a fully electronic way of filing the submission for the "Sale Deed", however, it's taking a significant amount of time for the whole process to complete.

## What it does

The Sale Deed Registry as the name says, it's responsible for handling the sale deed fulfillment between the seller and the buyer. The main actors of the system are - Buyer, Seller and Payee.

## How I built it

The heart of the "Sale Deed Registry" is based on the Stratis Smart Contract. 

In addition to maintaining the Sale Deed record or information about the property as an asset within the blockchain via Smart Contract, it's is also responsible for handling the fee payment and other necessary sale deed verification checks such as "Encumbrance" clearance etc. The system is designed with the contract as a core requirement and the actors just operating the contract with the required state being maintained within the contract. All operations are executed or handled based on the qualified state.

The following are the "Sale Deed Registry" Smart Contract States

<ol>
<li>Init Application</li>
<li>State Review</li>
<li>Complete Review</li>
<li>Reject Application</li>
<li>Pay Application Transfer Fee</li>
<li>Transfer Ownership</li>
</ol>

Here's the high-level overview about the Sale Deed Application Process coded on a Console App to demonstrate the end to end workflow.


## Challenges I ran into

The challenging aspect is to deal with the multiple states and making sure the async operations have been successfully completed for handling other contract operations or activities. Since there wasn't a notification mechanism to understand whether or not the operation has been complete, the polling approach was taken into consideration. However, not to run into the infinite looping problem, there was a need to introduce a configurable timeout for checking the transaction/operation completeness.  

Designing a single contact to handle the "Asset" specific persistent state was also a challenging aspect and was addressed using a property as a dictionary approach.

## Accomplishments that I'm proud of

I am really happy to successfully handle the Smart Contract operations including the state or persistence management. 

I got an assurance from the Indian Government wanted to explore, try it out and see how it really works for the public.

## What I learned

I learned how to code a Stratis based Smart contract with ease. Generally the smart contract programming is not so easy and yet times it's a great challenge as it requires a different mindset, a completely different use case and the highly challenging aspect is to understand on how the contracts can be built by using a limited resources, data types etc.

## What's next for Sale Deed Registry

The next big thing which I will be doing is, to give a public presentation and demo to the "Indian Government" in-ordination with the NIC (National Informatics Center). I wished to get as much feedback and then improve or extend the same. 
