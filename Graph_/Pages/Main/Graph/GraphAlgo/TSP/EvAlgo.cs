using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Graph_
{
    public partial class TSP
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public List<T> Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random_generator.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }


        Random random_generator = new Random();
        List<Individual> population;

        class Population
        {
            public List<Individual> individuals;
            int fixed_amount;
            TSP _src;

            public int Amount { get { return fixed_amount; } }


            public void Add(Individual individual)
            {
                individuals.Add(individual);
                Sort_invididuals();
            }

            public Individual GetI(int index)
            {
                return individuals[index];
            }
            public Population(TSP _src, List<Individual> individuals)
            {
                this.individuals = individuals;
                this._src = _src;
                fixed_amount = individuals.Count;
                Sort_invididuals();
            }

            public Population(TSP _src, int amount, List<Individual> started_individuals=null)
            {
                if (started_individuals == null)
                {
                    started_individuals = new List<Individual>();
                }

                fixed_amount = amount + started_individuals.Count;
                this._src = _src;
                individuals = new List<Individual>(fixed_amount);
                var src_range = Enumerable.Range(1, _src.numberOfVertices-1);
                for (int i=0; i< amount; i++)
                {
                    List<int> _tmp_list = _src.Shuffle(new List<int>(src_range));
                    _tmp_list.Add(0);
                    _tmp_list.Insert(0, 0);
                    individuals.Add(new Individual(_src, _tmp_list));
                }
                individuals.AddRange(started_individuals.GetRange(0, started_individuals.Count));
                Sort_invididuals();
            }

            void Sort_invididuals()
            {
                individuals.Sort((Individual a, Individual b) => { return Convert.ToInt32(a.Value - b.Value); });
            }

            public void ExecuteSelection(int N_bests = 5)
            {

                List<Individual> new_population = new List<Individual>(fixed_amount);
                
                for(int i=0; i < N_bests; i++)
                {
                    new_population.Add(individuals[i]);
                }

                for (int i = 0; i < fixed_amount - N_bests; i++)
                {
                    new_population.Add(individuals[_src.random_generator.Next(0, fixed_amount)]);
                }



                individuals = new_population;

                Sort_invididuals();
            }

            public void Mate(int N_bests = 5)
            {
                List<Individual> to_mate = new List<Individual>(fixed_amount);

                for (int i = 0; i < N_bests; i++)
                {
                    to_mate.Add(individuals[i]);
                }

                for (int i = 0; i < fixed_amount - N_bests; i++)
                {
                    int first_competitor = _src.random_generator.Next(N_bests + 1, fixed_amount),
                        second_competitor = _src.random_generator.Next(N_bests + 1, fixed_amount);

                    Individual winner = individuals[first_competitor].Value < individuals[second_competitor].Value ? individuals[second_competitor] : individuals[first_competitor];
                    to_mate.Add(winner);
                }


                for (int i=0; i<to_mate.Count; i++)
                {
                    Individual parrent1 = to_mate[i],
                               parrent2 = to_mate[_src.random_generator.Next(0, to_mate.Count)];
                    Individual offspring = OX_crossover(parrent1, parrent2);

                    double mutationRate = Individual.Common(parrent1, parrent2);
                    
                    if (mutationRate > 0.1)
                    {
                        if (mutationRate > 0.6)
                        {
                            if (_src.random_generator.Next(0, 100) > 70)
                            {
                                int start = _src.random_generator.Next(2, offspring.Chromos.Count - 2);
                                int count = _src.random_generator.Next(1, Convert.ToInt32((offspring.Chromos.Count - 1 - start) * (mutationRate)));
                                offspring.ReverseMutation(start, count);
                            }
                            if (_src.random_generator.Next(0, 100) < mutationRate*100)
                            {
                                for (int j=0; j<Convert.ToInt32(mutationRate*3.3); j++)
                                {
                                    int value = _src.random_generator.Next(1, _src.numberOfVertices);
                                    int position = _src.random_generator.Next(1, _src.numberOfVertices);

                                    offspring.InsertMutation(position, value);
                                }
                                

                            }
                        }
                        else
                        {
                            offspring.SwapMutation(_src.random_generator.Next(2, offspring.Chromos.Count - 2), _src.random_generator.Next(2, offspring.Chromos.Count - 2));
                        }
                    }

                    individuals.Add(offspring);
                }

                Sort_invididuals();
            }

            Individual OX_crossover(Individual parent1, Individual parent2)
            {
                List<int> offspring = new List<int>(new int[parent1.Chromos.Count]);
                int primary_parent_number = _src.random_generator.Next(0, 2);

                Individual primary_parent = primary_parent_number == 0 ? parent1 : parent2;
                Individual second_parent = primary_parent_number == 0 ? parent2 : parent1;

                var interval = Interval.get_random_interval(1, primary_parent.Chromos.Count-1, _src.random_generator);

                for (int i = interval.Start; i < interval.End; i++)
                {
                    offspring[i] = primary_parent.Chromos[i];
                }

                List<int> values_to_add = new List<int>(interval.Length);

                HashSet<int> sub_values = new HashSet<int>(primary_parent.Chromos.GetRange(interval.Start, interval.Length));


                for (int i = 0; i < primary_parent.Chromos.Count; i++)
                {
                    if (!sub_values.Contains(second_parent.Chromos[i]))
                    {
                        values_to_add.Add(second_parent.Chromos[i]);
                    }
                }

                int j = 0;
                for (int i = 0; i < primary_parent.Chromos.Count - 1; i++)
                {
                    if (interval.in_interval(i))
                    {
                        continue;
                    }

                    offspring[i] = values_to_add[j];
                    j++;
                }

                return new Individual(_src, offspring);
            }

            public List<Individual> Get_N_Bests(int N)
            {
                return individuals.GetRange(0, N);
            }
        }

        class Individual
        {
            TSP _source;
            List<int> chromos;
            double value;

            public Individual(TSP source, List<int> chromos)
            {
                this._source = source;
                this.chromos = chromos;
                UpdateValue();
            }

            void UpdateValue()
            {
                value = this._source.calcWayLength(this.chromos);
            }

            public void ReverseMutation(int start, int count)
            {
                int end = start + count - 1;
                while(start < end)
                {
                    int tmp = chromos[end];
                    chromos[end] = chromos[start];
                    chromos[start] = tmp;
                    start++;
                    end--;
                }
                UpdateValue();
            }

            public void SwapMutation(int first, int second)
            {
                int tmp = chromos[second];
                chromos[second] = chromos[first];
                chromos[first] = tmp;
                UpdateValue();
            }

            public void InsertMutation(int postion, int value)
            {
                chromos.Remove(value);
                chromos.Insert(postion, value);
            }

            public static double Common(Individual individual1, Individual individual2)
            {
                int common = 0;
                for(int i=0; i<individual1.Chromos.Count; i++)
                {
                    if (individual1.Chromos[i] == individual2.Chromos[i])
                    {
                        common++;
                    }
                }
                return Convert.ToDouble(common) / individual1.Chromos.Count;
            }

            public List<int> Chromos { get { return chromos; } }
            public double Value { get { return value; } }
        }

        struct Interval
        {
            Tuple<int, int> interval;
            int length;

            public Interval(int start, int end)
            {
                interval = new Tuple<int, int>(start, end);
                length = interval.Item2 - interval.Item1;
            }

            public Interval(Tuple<int, int> interval)
            {
                this.interval = interval;
                length = interval.Item2 - interval.Item1;
            }

            public bool in_interval(int value)
            {
                return value >= interval.Item1 && value < interval.Item2;
            }

            public static Interval get_random_interval(int min_len, int max_len, Random random_generator)
            {
                int lower_bound = random_generator.Next(min_len, max_len);
                int upper_bound = random_generator.Next(lower_bound + 1, max_len);

                return new Interval(lower_bound, upper_bound);
            }

            public int Start { get { return interval.Item1; } }
            public int End { get { return interval.Item2; } }

            public int Length { get { return length; } }
        }


        void mainEvolutionLoop(CancellationToken cancel)
        {
            bool migration = Convert.ToBoolean(args["migration"]);
            int should_migrate = args["should_migrate"]; // migrate once in 1000 generations
            int amount_of_random_populations = args["num_rnd"];
            int amount_of_greedy_based_populations = args["num_greedy"];

            var greedy_ans = greedy().Item2;
            List<Individual> started_individuals = new List<Individual>();
            started_individuals.Add(new Individual(this, greedy_ans));

            setTSP(matrix, start);

            List<Population> populations = new List<Population>();

            for(int i=0; i<amount_of_random_populations; i++)
            {
                populations.Add(new Population(this, numberOfVertices * 10));
            }

            for(int i=0; i<amount_of_greedy_based_populations; i++)
            {
                populations.Add(new Population(this, numberOfVertices * 10, started_individuals));
            }

            int no_best_changes_counter = 0;
            while (true)
            {
                bool shouldUpdate = false;
                foreach(Population population in populations)
                {
                    if (cancel.IsCancellationRequested) return;
                    population.Mate();
                    population.ExecuteSelection();

                    Individual best = population.Get_N_Bests(1)[0];

                    if (best.Value < currentOptimalWeight)
                    {
                        shouldUpdate = true;
                        ans = new List<int>(best.Chromos);
                        currentOptimalWeight = best.Value;
                    }
                }
                no_best_changes_counter++;

                if (migration)
                {
                    if (no_best_changes_counter == should_migrate)
                    {
                        List<Individual> bests = new List<Individual>();
                        foreach (Population population in populations)
                        {
                            bests.Add(population.Get_N_Bests(1)[0]);
                            population.individuals.RemoveAt(0);
                        }

                        for (int i = 0; i < populations.Count; i++)
                        {
                            populations[i].Add(bests[(i + 1) % populations.Count]);
                        }
                        no_best_changes_counter = 0;
                    }
                }
                if (shouldUpdate)
                {
                    updater(new Tuple<double, List<int>>(currentOptimalWeight, ans));
                }
               
                //print_population(population);
            }
        }

        void print_population(Population population)
        {
            Individual best = population.Get_N_Bests(1)[0];
            Console.WriteLine($"BEST: {best.Value} : {best.Chromos}");
            for (int i=0; i<population.Amount; i++)
            {
                print_individual(population.GetI(i), i.ToString());
            }
        }

        void print_individual(Individual individual, string prefix="")
        {
            Console.WriteLine($"{prefix} {individual.Value} : {string.Join(",", individual.Chromos)}");
        }

        public async Task<bool> simpleEvolutionAlgo(Updater updater, CancellationToken cancel)
        {
            this.updater = updater;
            setTSP(matrix, start);

            await Task.Run(() => mainEvolutionLoop(cancel), cancel);
            return true;
        }
    }
}
