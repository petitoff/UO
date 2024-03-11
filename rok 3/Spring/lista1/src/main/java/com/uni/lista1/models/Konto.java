package com.uni.lista1.models;

import jakarta.persistence.*;

@Entity
public class Konto {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
    private String nrKonta;

    @ManyToOne
    private Klient klient;

    private Double saldo;

    @ManyToOne
    private RodzajKonta rodzaj;

    // Getters and Setters
}
